using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcApp1.Models;
using TelerikMvcApp1.Data;
using System.Data.SqlClient;
using System.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.UI.WebControls;
using TelerikMvcApp1.Data.Northwind;

namespace TelerikMvcApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.Registrar.RegistrarEntities1 regEnt = new Data.Registrar.RegistrarEntities1();
        private readonly Data.CanvasAPI.CanvasAPIEntities1 canEnt = new Data.CanvasAPI.CanvasAPIEntities1();
        private readonly Data.Northwind.NorthwindEntities _nwEnt = new NorthwindEntities();

        
        
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            var classYear = _nwEnt.vw_Matri_Grad_Dates
                .Where(c => c.campuscode == "cwru")
                .Where(c => c.Prog_status == "AC" || c.Prog_status == "LA")
                .GroupBy(c => c.gyr)
                .Select(c => c.FirstOrDefault())
                .Select(c => new { classYear = c.gyr })
                .Distinct()
                .Take(6)
                .OrderByDescending(c => c.classYear)
                .ToList();
            classYear.Add(new { classYear = "LOA" });
            classYear.Add(new { classYear = "PHD" });
            ViewData["classYear"] = classYear;

            return View();
            
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

       
        public string SaveSociety(string society)
        {
            Session["society"] = society;

            return society;
        }
        public string SaveGradYear(string classYear)
        {
            Session["classYear"] = classYear;

            return classYear;
        }
        public string SaveReport(string rRep)
        {
            Session["rostReps"] = rRep;

            return rRep;
        }
        public string SaveSelectedStudent(string StudentName)
        {
            Session["selectedStudent"] = StudentName;

            return StudentName;
        }


        public JsonResult GetIndiStudentInfo()
        {
            try
            {              
                var studentInfoDDL = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Personal Information" },
                    new SelectListItem { Text = "Clinical Evaluation" },
                    new SelectListItem { Text = "Electives Type A & B" },
                    new SelectListItem { Text = "Dean Notes" },
                    new SelectListItem { Text = "MSPE" },
                    new SelectListItem { Text = "USMLE" }

                };
                
                return Json(studentInfoDDL, JsonRequestBehavior.AllowGet);
            }
            catch
            {                
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

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

        public JsonResult GetStudentsDDL(string classYear, string society)
        {

            if (Session["classYear"] != null)
                classYear = Session["classYear"].ToString();

            if (Session["society"] != null)
                society = Session["society"].ToString();


            if (society == "All")
            {
                var allByYear = _nwEnt.v_studentsAll
                    .Where(x => x.gyr == classYear)
                    .Where(x => x.Prog_status == "AC")
                    .OrderBy(x => x.Emplid)
                    .Select(x => x.Emplid)
                    .ToList();

                var allInYear = allByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();



                var loaByYear = _nwEnt.v_studentsAll
                    .Where(c => c.campuscode == "cwru")
                    .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
                    .OrderBy(c => c.Emplid)
                    .Select(c => c.Emplid)
                    .ToList();

                var loaInYear = loaByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var allPersonalInfo = _nwEnt.v_studentsAll
                    .Where(x => allByYear.Contains(x.Emplid) || loaByYear.Contains(x.Emplid))
                    .OrderBy(x => x.Last_Name)
                    .Select(x => new { Name = x.studentname, Value = x.emaddr })
                    .ToList();

                return Json(allPersonalInfo, JsonRequestBehavior.AllowGet);
            }

            if (classYear == "LOA" || classYear == "PHD")
            {
                var loaByYear = _nwEnt.v_studentsAll
                    .Where(c => c.campuscode == "cwru")
                    .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
                    .OrderBy(c => c.Emplid)
                    .Select(c => c.Emplid)
                    .ToList();

                var loaInYear = loaByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var loaBySociety = _nwEnt.v_StudentsSOM
                    .Where(x => x.advisor_society.Contains(society))
                    .Where(x => loaByYear.Contains(x.Emplid))
                    .Select(x => x.Emplid)
                    .ToList();

                var loaInSociety = loaBySociety
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var loaPersonalInfo = _nwEnt.v_studentsAll
                    .Where(x => loaBySociety.Contains(x.Emplid) && (loaByYear.Contains(x.Emplid)))
                    .OrderBy(x => x.Last_Name)
                    .Select(x => new { Name = x.studentname, Value = x.emaddr })
                    .ToList();

                return Json(loaPersonalInfo, JsonRequestBehavior.AllowGet);


            }

            var gradsByYear = _nwEnt.v_StudentsSOM
                   .Where(x => x.gyr == classYear)
                   .Where(x => x.advisor_society.Contains(society))
                   .Where(x => x.Prog_status == "AC")
                   .OrderBy(x => x.Emplid)
                   .Select(x => x.Emplid)
                   .ToList();

            var gradsInYear = gradsByYear
                .Select(x => Int32.Parse(x))
                .ToList();

            var personalInfo = _nwEnt.v_studentsAll
                .Where(x => gradsByYear.Contains(x.Emplid))
                .OrderBy(x => x.Last_Name)
                .Select(x => new { Name = x.studentname, Value = x.emaddr })
                .ToList();

            return Json(personalInfo, JsonRequestBehavior.AllowGet);
        }

    }
}
