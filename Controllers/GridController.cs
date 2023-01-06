using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
//using Microsoft.AspNetCore.Mvc;
//using TelerikMvcApp1.Classes;
using TelerikMvcApp1.Data.Northwind;
using TelerikMvcApp1.Models;
using System.Collections.Generic;
using TelerikMvcApp1.Controllers;

namespace TelerikMvcApp1.Controllers
{
    public class GridController : Controller
    {
        private readonly Data.Registrar.RegistrarEntities1 _regEnt = new Data.Registrar.RegistrarEntities1();
        private readonly Data.CanvasAPI.CanvasAPIEntities1 _canvasAPIEntities1 = new Data.CanvasAPI.CanvasAPIEntities1();
        //private readonly Data.Easel.EaselEntities EaselEntities = new Data.Easel.EaselEntities();
        private readonly Data.Easel.Entities _easelEntities = new Data.Easel.Entities();

        public ActionResult Customers_Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var wind = new NorthwindEntities())
            {
                IQueryable<Customer> customers = wind.Customers;
                DataSourceResult result = customers.ToDataSourceResult(request, customer => new CustomerModel
                {
                    CustomerID = customer.CustomerID,
                    CustomerName = customer.CustomerName,
                    ContactName = customer.ContactName,
                    Address = customer.Address,
                    City = customer.City,
                    Country = customer.Country,
                    PostalCode = customer.PostalCode

                });
                return Json(result);
            }

        }

        public string GetStudCaseId(string studentCaseId)
        {
            Session["students"] = studentCaseId;

            return studentCaseId;
        }

        public ActionResult DeanNotes_Read([DataSourceRequest] DataSourceRequest request)
        {
            //var student = "mja122";
            var studentCaseId = String.Empty;
            if (Session["students"] != null)
                studentCaseId = Session["students"].ToString();

            var result = _regEnt.AdvisoryNotes.Where(x => x.emaddr == studentCaseId).Select(x => new DeanNotesModel()
            {
                Id = 1,
                studentCaseId = x.emaddr,
                edate = x.edate,
                adlogin = x.adlogin,
                etitle = x.etitle,
                enotes = x.enotes,
                notefile = x.notefile
            });
            return new JsonResult() { Data = result.ToDataSourceResult(request), MaxJsonLength = Int32.MaxValue };
        }

        /*public JsonResult IndividualStudent_Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var caseID = Session[""]
            }
        }*/
    }
} 
