using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelerikMvcApp1.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult TopMenu()
        {
            return View();
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






        //public JsonResult GetIndividualStudentDDL(string classYear, string society)
        //{

        //    if (Session["classYear"] != null)
        //        classYear = Session["classYear"].ToString();

        //    if (Session["society"] != null)
        //        society = Session["society"].ToString();


        //    if (society == "All")
        //    {
        //        var allByYear = regEnt.vw_Matri_Grad_Dates
        //            .Where(x => x.gyr == classYear)
        //            .Where(x => x.Prog_status == "AC")
        //            .OrderBy(x => x.Emplid)
        //            .Select(x => x.Emplid)
        //            .ToList();

        //        var allInYear = allByYear
        //            .Select(c => Int32.Parse(c))
        //            .ToList();



        //        var loaByYear = canEnt.v_studentsAll
        //            .Where(c => c.campuscode == "cwru")
        //            .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
        //            .OrderBy(c => c.Emplid)
        //            .Select(c => c.Emplid)
        //            .ToList();

        //        var loaInYear = loaByYear
        //            .Select(c => Int32.Parse(c))
        //            .ToList();

        //        var allPersonalInfo = regEnt.Personals
        //            .Where(x => allByYear.Contains(x.Emplid) || loaByYear.Contains(x.Emplid))
        //            .OrderBy(x => x.Last_Name)
        //            .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
        //            .ToList();

        //        return Json(allPersonalInfo, JsonRequestBehavior.AllowGet);
        //    }

        //    if (classYear == "LOA" || classYear == "PHD")
        //    {
        //        var loaByYear = canEnt.v_studentsAll
        //            .Where(c => c.campuscode == "cwru")
        //            .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
        //            .OrderBy(c => c.Emplid)
        //            .Select(c => c.Emplid)
        //            .ToList();

        //        var loaInYear = loaByYear
        //            .Select(c => Int32.Parse(c))
        //            .ToList();

        //        var loaBySociety = regEnt.vw_Matri_Grad_Dates
        //            .Where(x => x.advisor_society.Contains(society))
        //            .Where(x => loaByYear.Contains(x.Emplid))
        //            .Select(x => x.Emplid)
        //            .ToList();

        //        var loaInSociety = loaBySociety
        //            .Select(c => Int32.Parse(c))
        //            .ToList();

        //        var loaPersonalInfo = regEnt.Personals
        //            .Where(x => loaBySociety.Contains(x.Emplid) && (loaByYear.Contains(x.Emplid)))
        //            .OrderBy(x => x.Last_Name)
        //            .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
        //            .ToList();

        //        return Json(loaPersonalInfo, JsonRequestBehavior.AllowGet);


        //    }

        //    var gradsByYear = regEnt.vw_Matri_Grad_Dates
        //           .Where(x => x.gyr == classYear)
        //           .Where(x => x.advisor_society.Contains(society))
        //           .Where(x => x.Prog_status == "AC")
        //           .OrderBy(x => x.Emplid)
        //           .Select(x => x.Emplid)
        //           .ToList();

        //    var gradsInYear = gradsByYear
        //        .Select(x => Int32.Parse(x))
        //        .ToList();

        //    var personalInfo = regEnt.Personals
        //        .Where(x => gradsByYear.Contains(x.Emplid))
        //        .OrderBy(x => x.Last_Name)
        //        .Select(x => new { Name = x.Last_Name + ", " + x.First_Name })
        //        .ToList();

        //    return Json(personalInfo, JsonRequestBehavior.AllowGet);
        //}

        //public string SaveIndividualStudent(string indiStudent)
        //{
        //    Session["selectedIndiStudent"] = indiStudent;

        //    return indiStudent;
        //}




        //public ActionResult fsReportDetails()
        //{
        //    return PartialView();
        //}
        //public ActionResult fsElectivesRoster()
        //{
        //    return PartialView();
        //}
        //public ActionResult fsDeanNotes()
        //{
        //    return PartialView();
        //}

    }
}