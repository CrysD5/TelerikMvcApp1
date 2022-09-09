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
    public class DDLController : Controller
    {
        private readonly Data.Registrar.RegistrarEntities1 regEnt = new Data.Registrar.RegistrarEntities1();
        // GET: DDL
        public ActionResult Index()
        {
            var classYear = regEnt.vw_Matri_Grad_Dates
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
            Session["gradYear"] = classYear;

            return classYear;
        }

        public JsonResult CascadingGetStudents(string classYear, string society)
        {

            if (Session["gradYear"] != null)
                classYear = Session["gradYear"].ToString();

            if (Session["society"] != null)
                society = Session["society"].ToString();

            var gradsByYear = regEnt.vw_Matri_Grad_Dates
           .Where(x => x.gyr == classYear)
           .Where(x => x.advisor_society.Contains(society))
           .Where(x => x.Prog_status == "AC" || x.Prog_status == "LA")
           .OrderBy(x => x.Emplid)
           .Select(x => x.Emplid)
           .ToList();

            var gradsInYear = gradsByYear
            .Select(x => Int32.Parse(x))
            .ToList();

            var personalInfo = regEnt.Personals
            .Where(x => gradsByYear.Contains(x.Emplid))
            .OrderBy(x => x.Last_Name)
            .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
            .ToList();

            return Json(personalInfo, JsonRequestBehavior.AllowGet);
        }
    }
}