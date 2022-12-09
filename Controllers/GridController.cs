using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TelerikMvcApp1.Classes;
using TelerikMvcApp1.Data.Northwind;
using TelerikMvcApp1.Models;

namespace TelerikMvcApp1.Controllers
{
    public partial class GridController : Controller
    {
        private readonly Data.Registrar.RegistrarEntities1 regEnt = new Data.Registrar.RegistrarEntities1();
        private readonly Data.CanvasAPI.CanvasAPIEntities1 canvasAPIEntities1 = new Data.CanvasAPI.CanvasAPIEntities1();
        //private readonly Data.Easel.EaselEntities EaselEntities = new Data.Easel.EaselEntities();
        private readonly Data.Easel.Entities EaselEntities = new Data.Easel.Entities();
        private readonly Data.Northwind.NorthwindEntities _nwEnt = new NorthwindEntities();

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
            Session["stuCaseId"] = studentCaseId;

            return studentCaseId;
        }

        public ActionResult DeanNotes_Read([DataSourceRequest] DataSourceRequest request)
        {
            var student = "mja122";


            var result = regEnt.AdvisoryNotes.Where(x => x.emaddr == student).Select(x => new Models.DeanNotesModel()
            {
                Id = 1,
                emaddr = x.emaddr,
                edate = x.edate,
                adlogin = x.adlogin,
                etitle = x.etitle,
                enotes = x.enotes,
                notefile = x.notefile
            });
            return new JsonResult() { Data = result.ToDataSourceResult(request), MaxJsonLength = Int32.MaxValue };
        }



        




    }
} 
