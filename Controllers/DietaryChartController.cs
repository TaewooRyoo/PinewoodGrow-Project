using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PinewoodGrow.Models;
using PinewoodGrow.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace PinewoodGrow.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class DietarySourceController : Controller
    {
		private readonly GROWContext _context;

		public DietarySourceController(GROWContext context)
		{
			_context = context;
		}

		// GET: Home
		public async Task <IActionResult> Index()
		{

			var member = from m in _context.Members
				.Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
						 select m;

			//sort gender by datapoint
			double mInc2 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 3));
			double mInc3 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 4));
			double mInc5 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 9));
			double mInc10 = member.ToList().Count();


			List<DataPoint> dataPoints = new List<DataPoint>();

			//dataPoints.Add(new DataPoint("Obesity", mInc1));
			dataPoints.Add(new DataPoint("Lactose Intolerance", mInc2));
			dataPoints.Add(new DataPoint("Gluten Intolerance/Sensitivity", mInc3));
			//dataPoints.Add(new DataPoint("Digestive Disorders", mInc4)); 
			dataPoints.Add(new DataPoint("Food Allergies", mInc5));




			List<DataPoint> tabledataPoints = new List<DataPoint>();

			//tabledataPoints.Add(new DataPoint("Obesity", mInc1));
			tabledataPoints.Add(new DataPoint("Lactose Intolerance", mInc2));
			tabledataPoints.Add(new DataPoint("Gluten Intolerance/Sensitivity", mInc3));
			//tabledataPoints.Add(new DataPoint("Digestive Disorders", mInc4));
			tabledataPoints.Add(new DataPoint("Food Allergies", mInc5));


			ViewData["graphData"] = dataPoints.ToList();
            ViewData["tableData"] = tabledataPoints;

			return View();
		}


        public IActionResult DownloadReport()
        {
            var member = from m in _context.Members
                .Include(m => m.MemberDietaries).ThenInclude(m => m.Dietary)
                         select m;

            //sort gender by datapoint
            
            double mInc2 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 3));
            double mInc3 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 4));
            double mInc5 = member.ToList().Count(m => m.MemberDietaries.Any(s => s.DietaryID == 9));


            //How many rows?
            int numRows = 3;

            if (numRows > 0) //We have data
            {
                //Create a new spreadsheet from scratch.
                using (ExcelPackage excel = new ExcelPackage())
                {

                    //Note: you can also pull a spreadsheet out of the database if you
                    //have saved it in the normal way we do, as a Byte Array in a Model
                    //such as the UploadedFile class.
                    //
                    // Suppose...
                    //
                    // var theSpreadsheet = _context.UploadedFiles.Include(f => f.FileContent).Where(f => f.ID == id).SingleOrDefault();
                    //
                    //    //Pass the Byte[] FileContent to a MemoryStream
                    //
                    // using (MemoryStream memStream = new MemoryStream(theSpreadsheet.FileContent.Content))
                    // {
                    //     ExcelPackage package = new ExcelPackage(memStream);
                    // }

                    var workSheet = excel.Workbook.Worksheets.Add("Dietary Concerns Report");

                    workSheet.Cells[3, 1].Value = "Dietary Concerns";
                    workSheet.Cells[3, 2].Value = "No. of Member";

                    

                    workSheet.Cells[4, 1].Value = "Lactose Intolerance";
                    workSheet.Cells[4, 2].Value = mInc2;

                    workSheet.Cells[5, 1].Value = "Gluten Intolerance/Sensitivity";
                    workSheet.Cells[5, 2].Value = mInc3;

                    

                    workSheet.Cells[6, 1].Value = "Food Allergies";
                    workSheet.Cells[6, 2].Value = mInc5;

                    //Note: Cells[row, column]
                    //workSheet.Cells[3, 2].LoadFromCollection(mem, true);

                    //Style first column for dates
                    //workSheet.Column(1).Style.Numberformat.Format = "yyyy-mm-dd";

                    //Style fee column for currency
                    //workSheet.Column(2).Style.Numberformat.Format = "###,###.##";

                    //Note: You can define a BLOCK of cells: Cells[startRow, startColumn, endRow, endColumn]
                    //Make Date and Patient Bold
                    workSheet.Cells[4, 1, numRows + 3, 1].Style.Font.Bold = true;


                    //Note: these are fine if you are only 'doing' one thing to the range of cells.
                    //Otherwise you should USE a range object for efficiency

                    //using (ExcelRange totalfees = workSheet.Cells[numRows + 4, 4])//
                    //{
                    //    totalfees.Formula = "Sum(" + workSheet.Cells[4, 4].Address + ":" + workSheet.Cells[numRows + 3, 4].Address + ")";
                    //    totalfees.Style.Font.Bold = true;
                    //    totalfees.Style.Numberformat.Format = "$###,##0.00";
                    //}

                    //Set Style and backgound colour of headings
                    using (ExcelRange headings = workSheet.Cells[3, 1, 3, 6])
                    {
                        headings.Style.Font.Bold = true;
                        var fill = headings.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.LightBlue);
                    }

                    ////Boy those notes are BIG!
                    ////Lets put them in comments instead.
                    //for (int i = 4; i < numRows + 4; i++)
                    //{
                    //    using (ExcelRange Rng = workSheet.Cells[i, 7])
                    //    {
                    //        string[] commentWords = Rng.Value.ToString().Split(' ');
                    //        Rng.Value = commentWords[0] + "...";
                    //        //This LINQ adds a newline every 7 words
                    //        string comment = string.Join(Environment.NewLine, commentWords
                    //            .Select((word, index) => new { word, index })
                    //            .GroupBy(x => x.index / 7)
                    //            .Select(grp => string.Join(" ", grp.Select(x => x.word))));
                    //        ExcelComment cmd = Rng.AddComment(comment, "Apt. Notes");
                    //        cmd.AutoFit = true;
                    //    }
                    //}

                    //Autofit columns
                    workSheet.Cells.AutoFitColumns();
                    //Note: You can manually set width of columns as well
                    //workSheet.Column(7).Width = 10;

                    //Add a title and timestamp at the top of the report
                    workSheet.Cells[1, 1].Value = "Member's report by Dietary Concerns";
                    using (ExcelRange Rng = workSheet.Cells[1, 1, 1, 6])
                    {
                        Rng.Merge = true; //Merge columns start and end range
                        Rng.Style.Font.Bold = true; //Font should be bold
                        Rng.Style.Font.Size = 18;
                        Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    //Since the time zone where the server is running can be different, adjust to 
                    //Local for us.
                    DateTime utcDate = DateTime.UtcNow;
                    TimeZoneInfo esTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime localDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, esTimeZone);
                    using (ExcelRange Rng = workSheet.Cells[2, 6])
                    {
                        Rng.Value = "Created: " + localDate.ToShortTimeString() + " on " +
                            localDate.ToShortDateString();
                        Rng.Style.Font.Bold = true; //Font should be bold
                        Rng.Style.Font.Size = 12;
                        Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }

                    //Ok, time to download the Excel

                    //I usually stream the response back to avoid possible
                    //out of memory errors on the server if you have a large spreadsheet.
                    //NOTE: Since .NET Core 3 most Web Servers disallow sync IO so we
                    //need to temporarily change the setting for the server.
                    //If we can't then we will try to build the file and return a FileContentResult
                    var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
                    if (syncIOFeature != null)
                    {
                        syncIOFeature.AllowSynchronousIO = true;
                        using (var memoryStream = new MemoryStream())
                        {
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.Headers["content-disposition"] = "attachment;  filename=Member Dietary Concerns Report.xlsx";
                            excel.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.Body);
                        }
                    }
                    else
                    {
                        try
                        {
                            Byte[] theData = excel.GetAsByteArray();
                            string filename = "Member Income Dietary Concerns Report.xlsx";
                            string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            return File(theData, mimeType, filename);
                        }
                        catch (Exception)
                        {
                            return NotFound();
                        }
                    }
                }
            }
            return NotFound();
        }

    }
}
