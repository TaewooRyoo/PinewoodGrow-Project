﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PinewoodGrow.Data;
using PinewoodGrow.Models;
using PinewoodGrow.Models.Temp;

namespace PinewoodGrow.Controllers
{
    public class TempHouseholdsController : Controller
    {
        private readonly GROWContext _context;

        #region Partial Views

        public PartialViewResult TempMemberList(int id)
        {
            ViewBag.TempMembers = _context.TempMembers.Where(a => a.TempHouseholdID == id)
                .Include(a => a.Gender).Include(a => a.MemberSituations)
                .ToList();

            return PartialView("_TempMemberList");
        }
        public PartialViewResult MemberSituationList(int id)
        {
            ViewBag.TempMemberSituations = _context.TempMemberSituations
                .Include(s => s.Situation)
                .Where(s => s.MemberID == id)
                .OrderBy(s => s.Situation.Name)
                .ToList();
            return PartialView("_MemberSituationList");
        }

        #endregion

        #region Custom Controllers

        #region Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, string[] selectedOptions, string Lat, string Lng, string AddressName, string postal, string city, string placeID, string isFixedAddress, string FamilyName, string isActive)
        {
            var householdToupdate = await _context.TempHouseholds
                .Include(d => d.Address)
                .Include(d => d.Members)
                .Include(d => d.MemberHouseholds)
                .ThenInclude(d => d.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (householdToupdate == null)
            {
                return NotFound();
            }

            householdToupdate.IsFixedAddress = isFixedAddress == "true";

            /*household.FamilySize = householdToupdate.Members.Count + household.Dependants;*/

            householdToupdate.AddressID = householdToupdate.IsFixedAddress ? await GetAddressID(Lat, Lng, AddressName, placeID, postal, city) : (int?)null;


            if (await TryUpdateModelAsync(householdToupdate, ""))


                //Try updating it with the values posted
                if (await TryUpdateModelAsync<TempHousehold>(householdToupdate, "",
                    d => d.ID, d => d.AddressID, d => d.Dependants, d => d.FamilyName, d => d.FamilySize))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Details", new { householdToupdate.ID });
                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MemberExists(householdToupdate.ID))
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
                            ModelState.AddModelError("", "Unable to save: Duplicate Household Number.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Unable to save changes to the database. Try again, and if the problem persists see your system administrator.");
                        }
                    }
                }

            return RedirectToAction("Details", new { householdToupdate.ID });
        }

        #endregion

        #region Create Household

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHouseHold(int ID, string[] selectedOptions, string Lat, string Lng,
            string AddressName, string postal, string city, string placeID, string isFixedAddress, string FamilyName,
            string isActive)
        {

            var householdToupdate = await _context.TempHouseholds
                .Include(d => d.Address)
                .Include(d => d.Members)
                .Include(d => d.MemberHouseholds)
                .ThenInclude(d => d.Member)
                .FirstOrDefaultAsync(m => m.ID == ID);

            if (householdToupdate == null)
            {
                return NotFound();
            }

            householdToupdate.IsFixedAddress = isFixedAddress == "true";

            /*household.FamilySize = householdToupdate.Members.Count + household.Dependants;*/

            householdToupdate.AddressID = householdToupdate.IsFixedAddress ? await GetAddressID(Lat, Lng, AddressName, placeID, postal, city) : (int?)null;


            if (await TryUpdateModelAsync(householdToupdate, ""))
                //Try updating it with the values posted
                if (await TryUpdateModelAsync<TempHousehold>(householdToupdate, "",
                    d => d.ID, d => d.AddressID, d => d.Dependants, d => d.FamilyName, d => d.FamilySize))
                    await _context.SaveChangesAsync();

            

            var tmpHousehold = _context.TempHouseholds.FirstOrDefault(a => a.ID == ID);
            var tmpMembers = _context.TempMembers.Where(a => a.TempHouseholdID == ID)
                .Include(a=> a.MemberSituations)
                .Include(a=> a.MemberDietaries)
                .Include(a=> a.MemberDocuments)
                .Include(a=> a.MemberDietaries)
                .Include(a=> a.MemberIllnesses).ToList();
            int? AddressID = null;
            if (isFixedAddress.ToLower() == "true")
            {
                AddressID = ValidateAddress(tmpHousehold.AddressID);
            }

            var householdID = ValidateHouseHold(tmpHousehold, AddressID, tmpMembers.Count);

            tmpMembers.ForEach(a=> ValidateMembers(householdID, a));

            return RedirectToAction("Details", "Households", new { id = householdID });


        }


        private int ValidateAddress(int? id)
        {
            if (id == null) return -1;
            var tmpAddress = _context.TempAddresses.FirstOrDefault(a => a.ID == id);

            var addressToAdd = new Address
            {
                FullAddress = tmpAddress.FullAddress,
                City = tmpAddress.City,
                Latitude = tmpAddress.Latitude,
                Longitude = tmpAddress.Longitude,
                PlaceID = tmpAddress.PlaceID,
                PostalCode = tmpAddress.PostalCode,
            };
            _context.Addresses.Add(addressToAdd);
             _context.SaveChanges();

            return addressToAdd.ID;

        }
        private int ValidateHouseHold(TempHousehold tmpHouse, int? addressID, int familySize)
        {
            var House = new Household
            {
                AddressID = addressID,
                FamilyName = tmpHouse.FamilyName,
                IsFixedAddress = tmpHouse.IsFixedAddress,
                FamilySize = familySize,
                Dependants = 0
            };
            _context.Households.Add(House);
            _context.SaveChanges();
            return House.ID;

        }
        private bool ValidateMembers(int HouseID, TempMember tmpMember)
        {
            var member = new Member
            {
                FirstName = tmpMember.FirstName,
                LastName = tmpMember.LastName,
                Email = tmpMember.Email,
                Telephone = tmpMember.Telephone,
                Consent = tmpMember.Consent,
                DOB = tmpMember.DOB,
                CompletedOn = tmpMember.CompletedOn,
                GenderID = tmpMember.GenderID.GetValueOrDefault(),
                HouseholdID = HouseID,
                Income = 0,
                Notes = tmpMember.Notes,
                VolunteerID = tmpMember.VolunteerID.GetValueOrDefault(),
            };
            _context.Members.Add(member);
            _context.SaveChanges();

            var memberID = member.ID;

           var memberIncomes = tmpMember.MemberSituations.Select(a=> new MemberSituation
            {
                MemberID = memberID,
                SituationID = a.SituationID,
                SituationIncome = a.SituationIncome
            }).ToList();
            if(memberIncomes.Any())
                _context.MemberSituations.AddRange(memberIncomes);
   

            var memberIllnesses = tmpMember.MemberIllnesses.Select(a => new MemberIllness
            {
                MemberID = member.ID,
                IllnessID = a.IllnessID
            }).ToList();

            if (memberIllnesses.Any())
                _context.MemberIllnesses.AddRange(memberIllnesses);

            var MemberDietaries = tmpMember.MemberDietaries.Select(a => new MemberDietary
            {
                MemberID = memberID,
                DietaryID = a.DietaryID,
            }).ToList();
            if(MemberDietaries.Any()) 
                _context.MemberDietaries.AddRange(MemberDietaries);

            var MemberDocuments = tmpMember.MemberDocuments.Select(a => new MemberDocument
            {
                MemberID = memberID,
                FileContent = a.FileContent,
                FileName = a.FileName
            }).ToList();
            _context.MemberDocuments.AddRange(MemberDocuments);
            _context.SaveChanges();

            return true;

        }


        #endregion


        #endregion

        #region Main Controller Actions




        public TempHouseholdsController(GROWContext context)
        {
            _context = context;
        }

        // GET: TempHouseholds
        public async Task<IActionResult> Index()
        {
            var gROWContext = _context.TempHouseholds.Include(t => t.Address);
            return View(await gROWContext.ToListAsync());
        }

        // GET: TempHouseholds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempHousehold = await _context.TempHouseholds
                .Include(t => t.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tempHousehold == null)
            {
                return NotFound();
            }

            return View(tempHousehold);
        }

        // GET: TempHouseholds/Create
        public IActionResult Create(int? id)
        {
            var tempHousehold = new TempHousehold();
            if (_context.TempHouseholds.All(a => a.ID != id))
            {
                _context.Add(tempHousehold);
                _context.SaveChanges();
           
            }
            else
                tempHousehold = _context.TempHouseholds.FirstOrDefault(a => a.ID == id);

            return View(tempHousehold);
            /*return View("Edit", tempHousehold);*/
        }

        // POST: TempHouseholds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FamilySize,FamilyName,Dependants,IsFixedAddress,IsActive,AddressID")] TempHousehold tempHousehold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempHousehold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.TempAddresses, "ID", "ID", tempHousehold.AddressID);
            return View(tempHousehold);
        }

        // GET: TempHouseholds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempHousehold = await _context.TempHouseholds.FindAsync(id);
            if (tempHousehold == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.TempAddresses, "ID", "ID", tempHousehold.AddressID);
            return View(tempHousehold);
        }

        // POST: TempHouseholds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions, string Lat, string Lng, string AddressName, string postal, string city, string placeID, string isFixedAddress)
        {
            var householdToupdate = await _context.TempHouseholds
                .Include(d => d.Address)
                .Include(d => d.Members)
                .Include(d => d.MemberHouseholds)
                .ThenInclude(d => d.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (householdToupdate == null)
            {
                return NotFound();
            }

            householdToupdate.IsFixedAddress = isFixedAddress == "true";

            /*household.FamilySize = householdToupdate.Members.Count + household.Dependants;*/

            householdToupdate.AddressID = householdToupdate.IsFixedAddress ? await GetAddressID(Lat, Lng, AddressName, placeID, postal, city) : (int?)null;


            if (await TryUpdateModelAsync(householdToupdate, ""))


                //Try updating it with the values posted
                if (await TryUpdateModelAsync<TempHousehold>(householdToupdate, "",
                    d => d.ID, d => d.AddressID, d => d.Dependants, d => d.FamilyName, d => d.FamilySize))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Details", new { householdToupdate.ID });
                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MemberExists(householdToupdate.ID))
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
                            ModelState.AddModelError("", "Unable to save: Duplicate Household Number.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Unable to save changes to the database. Try again, and if the problem persists see your system administrator.");
                        }
                    }
                }

            return View("Create", householdToupdate);
        }

        // GET: TempHouseholds/Delete/5

        public async Task<IActionResult> DeleteTempHousehold(int ID)
        {
            var house = _context.TempHouseholds.FirstOrDefault(a => a.ID == ID);

            _context.Remove(house);
            await _context.SaveChangesAsync();


            //return View(await households.ToListAsync());
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Helper Functions
        private async Task<int> CreateAddress(TempAddress address)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();

            return address.ID;
        }
        private async Task<int> GetAddressID(string Lat, string Lng, string AddressName, string placeID, string postal, string city)
        {

            var tempAddress = new TempAddress()
            {
                FullAddress = AddressName,
                PostalCode = postal,
                City = city,
                PlaceID = placeID,
                Latitude = string.IsNullOrEmpty(Lat) ? (double?)null : Convert.ToDouble(Lat),
                Longitude = string.IsNullOrEmpty(Lng) ? (double?)null : Convert.ToDouble(Lng),
            };
            tempAddress = _context.TempAddresses.FirstOrDefault(a => a.PlaceID == tempAddress.PlaceID) ?? tempAddress;
            tempAddress.ID = tempAddress.ID == 0 ? await CreateAddress(tempAddress) : tempAddress.ID;
            return tempAddress.ID;

        }

        private bool TempHouseholdExists(int id)
        {
            return _context.TempHouseholds.Any(e => e.ID == id);
        }
        private bool MemberExists(int id)
        {
            return _context.Households.Any(e => e.ID == id);
        }

        #endregion

    }
}