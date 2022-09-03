using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcApp1.Models;
using TelerikMvcApp1.Data;
using System.Data.SqlClient;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace TelerikMvcApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.Registrar.RegistrarEntities1 regEnt = new Data.Registrar.RegistrarEntities1();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var classYear = regEnt.vw_Matri_Grad_Dates
                .Where(c => c.campuscode == "cwru")
                .Where(c => c.Prog_status == "AC" || c.Prog_status == "LA")
                .GroupBy(c => c.gyr)
                .Select(c => c.FirstOrDefault())
                .Select(c => new { classYear = c.gyr})
                .Distinct()
                .Take(6)
                .OrderByDescending(c => c.classYear)
                .ToList();
            classYear.Add(new {classYear = "LOA" });
            classYear.Add(new { classYear = "PHD" });
            ViewData["classYear"] = classYear;

            return View();
            //    .Where(x => x.exp_grad_year != null)                
            //    .Select(x => new { Year = x.exp_grad_year })
            //    .Distinct()
            //    .OrderByDescending(x => x.Year)
            //    .ToList();
            //classYear.Add(new { Year = "LOA" });
            //classYear.Add(new { Year = "PHD" });
            //ViewData["classYear"] = classYear;
            //return View();
        }

        public JsonResult GetSocDDL()
        {
            try
            {
                var society = new List<SelectListItem>
                {
                    new SelectListItem { Text = "All" },
                    new SelectListItem { Text = "Satcher" },
                    new SelectListItem { Text = "Robbins" },
                    new SelectListItem { Text = "Wearn" },
                    new SelectListItem { Text = "Blackwell" },
                    new SelectListItem { Text = "Geiger" },
                    new SelectListItem { Text = "Gerberding" }
                };
                ViewData["society"] = society;

                return Json(society, JsonRequestBehavior.AllowGet);
            }
            catch 
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetSocDDL()
        //{
        //    var society = regEnt.vw_Matri_Grad_Dates
        //        .Where(a => a.campuscode == "cwru")
        //        .Where(a => a.Prog_status == "AC" || a.Prog_status == "LA")
        //        .GroupBy(a => a.advisor_society)
        //        .Select(a => a.FirstOrDefault())
        //        .Select(a => new { Society = a.advisor_society })
        //        .Take(6)
        //        .Distinct()       
        //        .ToList();
        //    society.Add(new { Society = "All" });
        //    ViewData["society"] = society;
        //    //returns list of societies
        //    return Json(society, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetGyrDDL()
        //{
        //    var gradYears = regEnt.vw_Matri_Grad_Dates
        //        .Where(c => c.campuscode == "cwru")
        //        .Where(c => c.Prog_status == "AC" || c.Prog_status == "LA")
        //        //.Where(c => c.exp_grad_year == )
        //        .GroupBy(c => c.gyr)
        //        .Select(c => c.FirstOrDefault())
        //        .Select(c => new { GradYear = c.gyr })
        //        .Distinct()
        //        .Take(6)
        //        .OrderByDescending(c => c.GradYear)
        //        .ToList();

        //    gradYears.Add(new { GradYear = "LOA" });
        //    gradYears.Add(new { GradYear = "PHD" });

        //    return Json(gradYears, JsonRequestBehavior.AllowGet);

        //}

       
        public string SaveSociety(string society)
        {
            Session["society"] = society;

            return society;
        }
        public string SaveGradYear(string classYear)
        {
            Session["gradYear"] = classYear;

            return classYear;
        }

        public JsonResult CascadingGetStudents(string classYear, string society)
        {
            //classYear = "2022";
            if (Session["gradYear"] != null)
                classYear = Session["gradYear"].ToString();

                //classYear = string.Empty;
                //classYear = Session["gradYear"].ToString();
                               
            //string society = string.Empty;
            if (Session["society"] != null)
            society = Session["society"].ToString();

            //if (gradYear.Contains("LOA") || gradYear.Contains("PHD"))
            //{
            //    var leaveStatus = regEnt.vw_Matri_Grad_Dates.Where(x => x.Prog_status == "LA").Select(x => x.Emplid).ToList();

            //    var covertIdToInt = leaveStatus.Select(x => Int32.Parse(x)).ToList();

            //    var onLeaveList = regEnt.Personals
            //        .Where(x => leaveStatus.Contains(x.Emplid))
            //        .OrderBy(x => x.Last_Name)
            //        .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
            //        .ToList();

            //    return Json(onLeaveList, JsonRequestBehavior.AllowGet);
            //}
            
                var gradsByYear = regEnt.vw_Matri_Grad_Dates
               .Where(x => x.gyr == classYear)
               .Where(x => x.advisor_society.Contains(society))
               .OrderBy(x => x.Emplid)
               .Select(x => x.Emplid)
               .ToList();

                var gradsInYear = gradsByYear.Select(x => Int32.Parse(x)).ToList();

                var personalInfo = regEnt.Personals
                .Where(x => gradsByYear.Contains(x.Emplid))
                .OrderBy(x => x.Last_Name)
                .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
                .ToList();               


            return Json(personalInfo, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetTestDDL()
        //{
        //    //string society = string.Empty;
        //    //society = (string)Session["society"];
        //    //string gradYear = string.Empty;
        //    //gradYear = Convert.ToString(Session["gradYear"]);

        //    //string society = string.Empty;
        //    //string gradYear = string.Empty;
        //    //society = "Satcher";
        //    //gradYear = "2024";
        //    try
        //    {
        //        var gradsByYr = regEnt.vw_Matri_Grad_Dates
        //            .Where(x => x.gyr == gradYear)
        //            //.Where(x => x.Prog_status == "LA" || x.Prog_status == "DC")
        //            .Where(x => x.advisor_society.Contains(society))
        //            .OrderBy(x => x.Emplid)
        //            .Select(x => x.Emplid)
        //            .ToList();

        //        var gradsInYear = gradsByYr.Select(x => Int32.Parse(x)).ToList();

        //        var personalInfo = regEnt.Personals
        //        .Where(x => gradsByYr.Contains(x.Emplid))
        //        .OrderBy(x => x.Last_Name)
        //        .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
        //        .ToList();


        //        return Json(personalInfo, JsonRequestBehavior.AllowGet);
        //    }
        //    catch 
        //    {
        //        //ErrorLogger.LogError(ex, "SocietyDeansMVC", System.Reflection.MethodInfo.GetCurrentMethod().Name, Request.UserAgent);
        //        return Json("", JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult ReportDetails()
        {
            return PartialView();
        }
        public ActionResult FoundationBlks()
        {
            return PartialView();
        }
        public ActionResult CATscores()
        {
            return PartialView();
        }
    }
}
