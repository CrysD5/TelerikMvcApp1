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
                .Where(x => x.exp_grad_year != null)                
                .Select(x => new { Year = x.exp_grad_year })
                .Distinct()
                .OrderByDescending(x => x.Year)
                .ToList();
            //classYear.Add(new { Year = "LOA" });
            //classYear.Add(new { Year = "PHD" });
            ViewData["classYear"] = classYear;
            return View();
        }

        public JsonResult GetSocDDL()
        {
            var societies = regEnt.vw_Matri_Grad_Dates
                .Where(a => a.campuscode == "cwru")
                .Where(a => a.Prog_status == "AC" || a.Prog_status == "LA")
                .GroupBy(a => a.advisor_society)
                .Select(a => a.FirstOrDefault())
                .Select(a => new { Society = a.advisor_society })
                .Take(6)
                .Distinct()       
                .ToList();
            societies.Add(new { Society = "All" });
            //returns list of societies
            return Json(societies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGyrDDL()
        {
            var gradYears = regEnt.vw_Matri_Grad_Dates
                .Where(c => c.campuscode == "cwru")
                .Where(c => c.Prog_status == "AC" || c.Prog_status == "LA")
                //.Where(c => c.exp_grad_year == )
                .GroupBy(c => c.gyr)
                .Select(c => c.FirstOrDefault())
                .Select(c => new { GradYear = c.gyr })
                .Distinct()
                .Take(6)
                .OrderByDescending(c => c.GradYear)
                .ToList();

            gradYears.Add(new { GradYear = "LOA" });
            gradYears.Add(new { GradYear = "PHD" });

            return Json(gradYears, JsonRequestBehavior.AllowGet);

        }

        //public static List<StudentsModel> GetStudents()
        //{
        //   List<StudentsModel> students = from s in regEnt.Personals join si in regEnt.vw_Matri_Grad_Dates on 
        //}
        //public JsonResult GetStudentsDDL()
        //{
        //    var students = (from s in regEnt.Personals orderby s.Last_Name select s).ToList();

        //    return Json(students, JsonRequestBehavior.AllowGet);
        //}
        public string SaveSociety(string society)
        {
            Session["society"] = society;

            return society;
        }
        public int? SaveGradYear(int classYear)
        {
            Session["gradYear"] = classYear;

            return classYear;
        }

        public JsonResult CascadingGetStudents()
        {
            //if (Session["gradYear"] != null)
           string gradYear = string.Empty;
            gradYear = Convert.ToString(Session["gradYear"]);

            var gradsByYear = regEnt.vw_Matri_Grad_Dates
                .Where(x => x.exp_grad_year == gradYear)
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
