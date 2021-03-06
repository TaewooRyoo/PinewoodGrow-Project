using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PinewoodGrow.Data;
using PinewoodGrow.Models;
using PinewoodGrow.Models.Temp;
using PinewoodGrow.ViewModels;
using PinewoodGrow.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace PinewoodGrow.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly GROWContext _context;

        public MembersController(GROWContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string SearchString, int? page, int? pageSizeID, int? DietaryID, int? SituationID, int? IllnessID,
            string actionButton, string sortDirection = "asc", string sortField = "Member")
        {
            string[] sortOptions = new[] { "Member", "Age", "Family Size", "Income" };

            ViewData["Filtering"] = ""; //Asume not filtering

            ViewData["DietaryID"] = new SelectList(_context
                .Dietaries
                .OrderBy(d => d.Name), "ID", "Name");

            ViewData["SituationID"] = new SelectList(_context
                .Situations
                .OrderBy(s => s.Name), "ID", "Name");

            var members = from m in _context.Members
                //.Include(m => m.Address)
                .Include(m => m.Gender)
                //.Include(m => m.Volunteer)
                .Include(m => m.Household)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberSituations).ThenInclude(m => m.Situation)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
            select m;

            if (DietaryID.HasValue)
			{
                members = members.Where(m => m.MemberDietaries.Any(d => d.DietaryID == DietaryID));
                ViewData["Filtering"] = "show";
            }
            if (SituationID.HasValue)
            {
                members = members.Where(m => m.MemberSituations.Any(s => s.SituationID == SituationID));
                ViewData["Filtering"] = "show";
            }
            if (IllnessID.HasValue)
            {
                members = members.Where(m => m.MemberIllnesses.Any(i => i.IllnessID == IllnessID));
                ViewData["Filtering"] = "show";
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                members = members.Where(m => m.LastName.ToUpper().Contains(SearchString.ToUpper())
                                        || m.FirstName.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(actionButton))
            {
                page = 1;
                if (sortOptions.Contains(actionButton))
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }
            
            if (sortField == "Age")
            {
                if (sortDirection == "asc")
                {
                    members = members
                        .OrderByDescending(m => m.DOB);
                }
                else
                {
                    members = members
                        .OrderBy(m => m.DOB);
                }
            }
            else if (sortField == "Income")
            {
                if (sortDirection == "asc")
                {
                    members = members
                        .OrderBy(m => m.MemberSituations.ToList().Select(a => a.SituationIncome).Sum())
                        .ThenBy(m=> m.LastName);
                }
                else
                {
                    members = members
                        .OrderByDescending(m => m.MemberSituations.ToList().Select(a=> a.SituationIncome).Sum())
                        .ThenBy(m => m.LastName); ;
                }
            }
            else 
            {
                if (sortDirection == "asc")
                {
                    members = members
                        .OrderBy(m => m.LastName)
                        .ThenBy(m => m.FirstName);
                }
                else
                {
                    members = members
                        .OrderByDescending(m => m.LastName)
                        .ThenByDescending(m => m.FirstName);
                }
            }

            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Member>.CreateAsync(members.AsNoTracking(), page ?? 1, pageSize);

            //return View(await members.ToListAsync());
            return View(pagedData);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                //.Include(m => m.Address)
                .Include(m => m.Gender)
                //.Include(m => m.Volunteer)
                .Include(m => m.Household).ThenInclude(h=> h.Address)
                .Include(m => m.MemberDocuments)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberSituations).ThenInclude(m => m.Situation)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            var household = _context.Households
                .Include(a => a.Members)
                .ThenInclude(a => a.MemberSituations)
                .FirstOrDefault(a => a.ID == member.HouseholdID);

            if (household != null)
            {
                ViewData["HouseholdIncome"] = household.HouseIncome.ToString("C");
                

            }

            var orders = _context.Receipts
                .Include(a => a.Volunteer)
                .Include(a => a.Payment)
   
                .Where(a => a.MemberID == member.ID)
                .OrderBy(a => a.CreatedOn)
                .ToList();

            ViewData["Orders"] = orders;



            var stats = member.MemberSituations.OrderByDescending(a => a.SituationIncome)
                    .Select(a => new IncomeStats { Name = a.Situation.Name, Income = a.SituationIncome }).ToList();
            
            ViewData["IncomeStats"] = stats;
            ViewData["Colors1"] = new PieChartData(stats).Colors;
       

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create(int? HouseHoldID)
        {

            /*var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);*/

            var Tempmember = new TempMember()
            {
                HouseholdID = HouseHoldID
            };

            _context.TempMembers.Add(Tempmember);
            _context.SaveChanges();


            var member = new Member();

            /*PopulateAssignedTempDietaryData(Tempmember);
            PopulateAssignedTempSituationData(Tempmember);
            PopulateAssignedTempIllnessData(Tempmember);*/


            PopulateAssignedDietaryData(member);
            PopulateAssignedSituationData(member);
            PopulateAssignedIllnessData(member);
            PopulateTempDropDownLists(Tempmember);

            ViewData["MemberIncomeTypes"] = _context.Situations.Select(a => a);
            ViewData["TempMemberID"] = Tempmember.ID;
            return View(member);
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the dietific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Age,DOB,Telephone,Email,FamilySize,Income" +
            ",Notes,Consent,VolunteerID,CompletedOn,HouseholdID,GenderID")] Member member,
            string[] selectedOptions, string[] selectedSituationOptions, string[] selectedIllnessOptions, List<IFormFile> theFiles, int TempID
            )
            //string Lat, string Lng, string AddressName, string postal, string city
        {
            try
            {
                //member.AddressID =  await GetAddressID(Lat, Lng, AddressName, postal, city);
                UpdateMemberDietaries(selectedOptions, member);
                UpdateMemberIllnesses(selectedIllnessOptions, member);

                if (ModelState.IsValid)
                {
                    await AddDocumentsAsync(member, theFiles);
                    TempData["AlertMessage"] = "Member Information Saved Successfully....!";
                    _context.Add(member);
                    await _context.SaveChangesAsync();

                  var Situations =  _context.TempMemberSituations.Where(a => a.MemberID == TempID).Select(a => new MemberSituation
                        { MemberID = member.ID, SituationID = a.SituationID, SituationIncome = a.SituationIncome}).ToList();

                    await _context.AddRangeAsync(Situations);
                    await _context.SaveChangesAsync();
                    UpdateLicoInformation(member.HouseholdID);
                    /*if (selectedDietaryOptions != null)
                    {
                        foreach (var dietary in selectedDietaryOptions)
                        {
                            var dietaryToAdd = new MemberDietary { MemberID = member.ID, DietaryID = int.Parse(dietary) };
                            member.MemberDietaries.Add(dietaryToAdd);
                        }
                    }*/
                    if (selectedSituationOptions != null)
                    {
                        foreach (var situation in selectedSituationOptions)
                        {
                            var situationToAdd = new MemberSituation { MemberID = member.ID, SituationID = int.Parse(situation) };
                            member.MemberSituations.Add(situationToAdd);
                        }
                    }
                    /*if (selectedIllnessOptions != null)
                    {
                        foreach (var illness in selectedIllnessOptions)
                        {
                            var illnessToAdd = new MemberIllness { MemberID = member.ID, IllnessID = int.Parse(illness) };
                            member.MemberIllnesses.Add(illnessToAdd);
                        }
                    }*/


                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE"))
                {
                    ModelState.AddModelError("", "Unable to save: Duplicate Email Addresses.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes to the database. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateAssignedSituationData(member);
            PopulateAssignedDietaryData(member);
            PopulateAssignedIllnessData(member);
            PopulateDropDownLists(member);
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                //.Include(m => m.Address)
                .Include(m => m.MemberDocuments)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberSituations).ThenInclude(m => m.Situation)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (member == null)
            {
                return NotFound();
            }

            PopulateAssignedSituationData(member);
            PopulateAssignedDietaryData(member);
            PopulateAssignedIllnessData(member);
            PopulateDropDownLists(member);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the dietific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions, string[] selectedSituationOptions
            , string[] selectedIllnessOptions, List<IFormFile> theFiles)
        {
            var memberToUpdate = await _context.Members
                //.Include(m => m.Address)
                .Include(m => m.MemberDocuments)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (memberToUpdate == null)
            {
                return NotFound();
            }

            UpdateMemberDietaries(selectedOptions, memberToUpdate);
            UpdateMemberSituation(selectedSituationOptions, memberToUpdate);
            UpdateMemberIllnesses(selectedIllnessOptions, memberToUpdate);



            if (await TryUpdateModelAsync<Member>(memberToUpdate, "", m => m.FirstName, m => m.LastName, m => m.Age, m => m.DOB, m => m.Telephone, 
                m => m.Email, m => m.Income, m => m.Notes, m => m.Consent,  m => m.CompletedOn, m => m.HouseholdID, m => m.GenderID))
            //m => m.FamilySize, m => m.AddressID, m => m.Address
            {
                try
                {
                    await AddDocumentsAsync(memberToUpdate, theFiles);
                    await _context.SaveChangesAsync();

                    var HouseholdUpdate =
                        await _context.Households.Include(a => a.Members).ThenInclude(a => a.MemberSituations)
                            .FirstOrDefaultAsync(a => a.ID == memberToUpdate.HouseholdID);
                    var licoInfos = _context.LICOInfos.Where(a => a.HouseholdID == HouseholdUpdate.ID);

                    if (Math.Abs(licoInfos.FirstOrDefault(a=> a.CreatedOn == licoInfos.Max(b=> b.CreatedOn)).Income - HouseholdUpdate.HouseIncome) > 0.1)
                    {
                        UpdateLicoInformation(memberToUpdate.HouseholdID);
                    }

                    return RedirectToAction("Details", new { memberToUpdate.ID });
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(memberToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE"))
                    {
                        ModelState.AddModelError("", "Unable to save: Duplicate Email Addresses.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes to the database. Try again, and if the problem persists see your system administrator.");
                    }
                }
            }
            PopulateAssignedSituationData(memberToUpdate);
            PopulateAssignedDietaryData(memberToUpdate);
            PopulateAssignedIllnessData(memberToUpdate);
            PopulateDropDownLists(memberToUpdate);

            var memberToDisplay = await _context.Members
                //.Include(m => m.Address)
                .Include(m => m.MemberDocuments)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
                .Include(a=> a.MemberSituations).ThenInclude(a=> a.Situation)
                .FirstOrDefaultAsync(m => m.ID == id);
            return View(memberToDisplay);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                //.Include(m => m.Address)
                .Include(m => m.Gender)
                //.Include(m => m.Volunteer)
                .Include(m => m.Household)
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                .Include(m => m.MemberSituations).ThenInclude(m => m.Situation)
                .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members
               //.Include(m => m.Address)
               .Include(m => m.Gender)
               //.Include(m => m.Volunteer)
               .Include(m => m.Household)
               .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
               .Include(m => m.MemberSituations).ThenInclude(m => m.Situation)
               .Include(m => m.MemberIllnesses).ThenInclude(m => m.Illness)
               .FirstOrDefaultAsync(m => m.ID == id);

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #region Data Display

        

 
        private void PopulateAssignedDietaryData(Member member)
        {
            //For this to work, you must have Included the child collection in the parent object
            var allOptions = _context.Dietaries;
            var currentOptionsHS = new HashSet<int>(member.MemberDietaries.Select(b => b.DietaryID));
            //Instead of one list with a boolean, we will make two lists
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var d in allOptions)
            {
                if (currentOptionsHS.Contains(d.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
            }
            /*var currentOptionIDs = new HashSet<int>(member.MemberDietaries.Select(b => b.DietaryID));
            var checkBoxes = new List<CheckOptionVM>();
            foreach (var option in allOptions)
            {
                checkBoxes.Add(new CheckOptionVM
                {
                    ID = option.ID,
                    DisplayText = option.Name,
                    Assigned = currentOptionIDs.Contains(option.ID)
                });
            }

            ViewData["DietOptions"] = checkBoxes;*/

            ViewData["selDietOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availDietOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
        private void UpdateMemberDietaries(string[] selectedOptions, Member memberToUpdate)
        {
            if (selectedOptions == null)
            {
                memberToUpdate.MemberDietaries = new List<MemberDietary>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var currentOptionsHS = new HashSet<int>(memberToUpdate.MemberDietaries.Select(b => b.DietaryID));
            foreach (var d in _context.Dietaries)
            {
                if (selectedOptionsHS.Contains(d.ID.ToString()))//it is selected
                {
                    if (!currentOptionsHS.Contains(d.ID))//but not currently in the Member's collection - Add it!
                    {
                        memberToUpdate.MemberDietaries.Add(new MemberDietary
                        {
                            DietaryID = d.ID,
                            MemberID = memberToUpdate.ID
                        });
                    }
                }
                else //not selected
                {
                    if (currentOptionsHS.Contains(d.ID))//but is currently in the Member's collection - Remove it!
                    {
                        MemberDietary dietToRemove = memberToUpdate.MemberDietaries.FirstOrDefault(m => m.DietaryID == d.ID);
                        _context.Remove(dietToRemove);
                    }
                }
            }
        }

        private void PopulateAssignedSituationData(Member member)
        {
            //For this to work, you must have Included the PatientConditions 
            //in the Patient
            var allOptions = _context.Situations;
            var currentOptionIDs = new HashSet<int>(member.MemberSituations.Select(b => b.SituationID));
            var checkBoxes = new List<IncomeOption>();
            foreach (var option in allOptions)
            {
                checkBoxes.Add(new IncomeOption
                {
                    ID = option.ID,
                    Name = option.Name,
                    Summary = option.Name,
                    Assigned = currentOptionIDs.Contains(option.ID)
                });
            }
            ViewData["SituationOptions"] = checkBoxes;
        }
        private void UpdateMemberSituation(string[] selectedSituationOptions, Member memberToUpdate)
        {
            if (selectedSituationOptions == null)
            {
                memberToUpdate.MemberSituations = new List<MemberSituation>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedSituationOptions);
            var memberOptionsHS = new HashSet<int>
                (memberToUpdate.MemberSituations.Select(s => s.SituationID));
            foreach (var option in _context.Dietaries)
            {
                if (selectedOptionsHS.Contains(option.ID.ToString()))
                {
                    if (!memberOptionsHS.Contains(option.ID))
                    {
                        memberToUpdate.MemberSituations.Add(new MemberSituation { MemberID = memberToUpdate.ID, SituationID = option.ID });
                    }
                }
                else
                {
                    if (memberOptionsHS.Contains(option.ID))
                    {
                        MemberSituation situationToRemove = memberToUpdate.MemberSituations.SingleOrDefault(s => s.SituationID == option.ID);
                        _context.Remove(situationToRemove);
                    }
                }
            }
        }

        private void PopulateAssignedIllnessData(Member member)
        {
            //For this to work, you must have Included the child collection in the parent object
            var allOptions = _context.Illnesses;
            var currentOptionsHS = new HashSet<int>(member.MemberIllnesses.Select(b => b.IllnessID));
            //Instead of one list with a boolean, we will make two lists
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var d in allOptions)
            {
                if (currentOptionsHS.Contains(d.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
            }

            ViewData["selIllOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availIllOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
        private void UpdateMemberIllnesses(string[] selectedOptions, Member memberToUpdate)
        {
            if (selectedOptions == null)
            {
                memberToUpdate.MemberIllnesses = new List<MemberIllness>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var currentOptionsHS = new HashSet<int>(memberToUpdate.MemberIllnesses.Select(b => b.IllnessID));
            foreach (var d in _context.Illnesses)
            {
                if (selectedOptionsHS.Contains(d.ID.ToString()))//it is selected
                {
                    if (!currentOptionsHS.Contains(d.ID))//but not currently in the Member's collection - Add it!
                    {
                        memberToUpdate.MemberIllnesses.Add(new MemberIllness
                        {
                            IllnessID = d.ID,
                            MemberID = memberToUpdate.ID
                        });
                    }
                }
                else //not selected
                {
                    if (currentOptionsHS.Contains(d.ID))//but is currently in the Member's collection - Remove it!
                    {
                        MemberIllness illToRemove = memberToUpdate.MemberIllnesses.FirstOrDefault(m => m.IllnessID == d.ID);
                        _context.Remove(illToRemove);
                    }
                }
            }
        }

        private async Task AddDocumentsAsync(Member member, List<IFormFile> theFiles)
        {
            foreach (var f in theFiles)
            {
                if (f != null)
                {
                    string mimeType = f.ContentType;
                    string fileName = Path.GetFileName(f.FileName);
                    long fileLength = f.Length;                    
                    if (!(fileName == "" || fileLength == 0))
                    {
                        MemberDocument d = new MemberDocument();
                        using (var memoryStream = new MemoryStream())
                        {
                            await f.CopyToAsync(memoryStream);
                            d.FileContent.Content = memoryStream.ToArray();
                        }
                        d.FileContent.MimeType = mimeType;
                        d.FileName = fileName;
                        member.MemberDocuments.Add(d);
                    };
                }
            }
        }

        //For Adding Dietary
        private SelectList DietarySelectList(string skip)
        {
            //default query if no values to avoid
            var DietaryQuery = _context.Dietaries
                .OrderBy(d => d.Name);
            if (!String.IsNullOrEmpty(skip))
            {
                //Conver the string to an array of integers
                //so we can make sure we leave them out of the data we download
                string[] avoidStrings = skip.Split(',');
                int[] skipKeys = Array.ConvertAll(avoidStrings, s => int.Parse(s));
                DietaryQuery = _context.Dietaries
                    .Where(s => !skipKeys.Contains(s.ID))
                .OrderBy(d => d.Name);
            }
            return new SelectList(DietaryQuery, "ID", "Name");
        }
        [HttpGet]
        public JsonResult GetDietaries(string skip)
        {
            return Json(DietarySelectList(skip));
        }

        //For Adding Illness
        private SelectList IllnessSelectList(string skip)
        {
            //default query if no values to avoid
            var IllnessQuery = _context.Illnesses
                .OrderBy(d => d.Name);
            if (!String.IsNullOrEmpty(skip))
            {
                //Conver the string to an array of integers
                //so we can make sure we leave them out of the data we download
                string[] avoidStrings = skip.Split(',');
                int[] skipKeys = Array.ConvertAll(avoidStrings, s => int.Parse(s));
                IllnessQuery = _context.Illnesses
                    .Where(s => !skipKeys.Contains(s.ID))
                .OrderBy(d => d.Name);
            }
            return new SelectList(IllnessQuery, "ID", "Name");
        }
        [HttpGet]
        public JsonResult GetIllnesses(string skip)
        {
            return Json(IllnessSelectList(skip));
        }

        private List<CheckOptionVM> DietaryCheckboxList(string skip)
        {
            //default query if no values to avoid
            var DietaryQuery = _context.Dietaries
                .OrderBy(d => d.Name);
            if (!String.IsNullOrEmpty(skip))
            {
                //Conver the string to an array of integers
                //so we can make sure we leave them out of the data we download
                string[] avoidStrings = skip.Split(',');
                int[] skipKeys = Array.ConvertAll(avoidStrings, s => int.Parse(s));
                DietaryQuery = _context.Dietaries.OrderBy(d => d.Name);
                return DietaryQuery.Select(a => new CheckOptionVM
                {
                    ID = a.ID,
                    DisplayText = a.Name,
                    Assigned = skipKeys.Contains(a.ID)
                }).ToList();

            }
         

            return DietaryQuery.Select(a => new CheckOptionVM
            {
                ID = a.ID,
                DisplayText = a.Name,
            }).ToList();
        }
        [HttpGet]
        public JsonResult GetDietariesCheckbox(string skip)
        {
            return Json(DietaryCheckboxList(skip));
        }


        private void PopulateDropDownLists(Member member = null)
        {
            //ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "City", member?.AddressID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Name", member?.GenderID);
            //ViewData["VolunteerID"] = new SelectList(_context.Volunteers, "ID", "FullName", member?.VolunteerID);
            ViewData["HouseSummary"] = new SelectList(_context.Households, "ID", "HouseSummary", member?.HouseholdID);
            ViewData["MemberSituationID"] = new SelectList(_context.MemberSituations, "ID", "Summary", member?.MemberSituations);
        }

        public PartialViewResult MemberSituationList(int id)
        {
            ViewBag.MemberSituations = _context.MemberSituations
                .Include(s => s.Situation)
                .Where(s => s.MemberID == id)
                .OrderBy(s => s.Situation.Name)
                .ToList();
            return PartialView("_MemberSituationList");
        }

        public async Task<FileContentResult> Download(int id)
        {
            var theFile = await _context.UploadedFiles
                .Include(d => d.FileContent)
                .Where(f => f.ID == id)
                .FirstOrDefaultAsync();
            return File(theFile.FileContent.Content, theFile.FileContent.MimeType, theFile.FileName);
        }

        /*private async Task<int> GetAddressID(string Lat, string Lng, string AddressName, string postal, string city)
        {

            var tempAddress = new Address()
            {
                FullAddress = AddressName,
                PostalCode = postal,
                City = city,
                Latitude = string.IsNullOrEmpty(Lat) ? (double?)null : Convert.ToDouble(Lat),
                Longitude = string.IsNullOrEmpty(Lng) ? (double?)null : Convert.ToDouble(Lng),
            };

            if (!_context.Addresses.Any(a => a.FullAddress == tempAddress.FullAddress && a.PostalCode == tempAddress.PostalCode))
            {
                _context.Addresses.Add(tempAddress);
                await _context.SaveChangesAsync();
            }
            return  (await _context.Addresses.FirstOrDefaultAsync(a => a.FullAddress == tempAddress.FullAddress && a.PostalCode == tempAddress.PostalCode)).ID;

        }*/


        #region MyRegion
        private void PopulateTempDropDownLists(TempMember member = null)
        {
            //ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "City", member?.AddressID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Name", member?.GenderID);
            ViewData["VolunteerID"] = new SelectList(_context.Volunteers, "ID", "FullName", member?.VolunteerID);
            ViewData["HouseSummary"] = new SelectList(_context.Households, "ID", "HouseSummary", member?.HouseholdID);
            ViewData["MemberSituationID"] = new SelectList(_context.MemberSituations, "ID", "Summary", member?.MemberSituations);
        }
        private void PopulateAssignedTempDietaryData(TempMember member)
        {
            //For this to work, you must have Included the child collection in the parent object
            var allOptions = _context.Dietaries;
            var currentOptionsHS = new HashSet<int>(member.MemberDietaries.Select(b => b.DietaryID));
            //Instead of one list with a boolean, we will make two lists
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var d in allOptions)
            {
                if (currentOptionsHS.Contains(d.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
            }

            ViewData["selDietOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availDietOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }

        private void PopulateAssignedTempSituationData(TempMember member)
        {
            //For this to work, you must have Included the PatientConditions 
            //in the Patient
            var allOptions = _context.Situations;
            var currentOptionIDs = new HashSet<int>(member.MemberSituations.Select(b => b.SituationID));
            var checkBoxes = new List<IncomeOption>();
            foreach (var option in allOptions)
            {
                checkBoxes.Add(new IncomeOption
                {
                    ID = option.ID,
                    Name = option.Name,
                    Summary = option.Name,
                    Assigned = currentOptionIDs.Contains(option.ID)
                });
            }
            ViewData["SituationOptions"] = checkBoxes;
        }


        private void PopulateAssignedTempIllnessData(TempMember member)
        {
            //For this to work, you must have Included the child collection in the parent object
            var allOptions = _context.Illnesses;
            var currentOptionsHS = new HashSet<int>(member.MemberIllnesses.Select(b => b.IllnessID));
            //Instead of one list with a boolean, we will make two lists
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var d in allOptions)
            {
                if (currentOptionsHS.Contains(d.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = d.ID,
                        DisplayText = d.Name
                    });
                }
            }

            ViewData["selIllOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availIllOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }


        #endregion
        #endregion

        private async void UpdateLicoInformation(int householdID)
        {
            var household = await _context.Households.Include(a => a.Members).ThenInclude(a => a.MemberSituations)
                .Include(a => a.Dependant).FirstOrDefaultAsync(a => a.ID == householdID);

            var LicoInfo = new LICOInfo()
            {
                HouseholdID = householdID,
                FamilySize = household.Dependant.Count + household.Members.Count,
                Income = household.HouseIncome,
            };
            LicoInfo.Verify();
            _context.Add(LicoInfo);
            await _context.SaveChangesAsync();


        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.ID == id);
        }
    }
}
