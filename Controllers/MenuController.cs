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
    }
}