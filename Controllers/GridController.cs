using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TelerikMvcApp1.Models;

namespace TelerikMvcApp1.Controllers
{
    public partial class GridController : Controller
    {
		private readonly Data.Registrar.RegistrarEntities1 regEnt = new Data.Registrar.RegistrarEntities1();
		public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
		{
			var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
			{
				ContactName = i.ToString(),
				OrderID = i,
				Freight = i * 10,
				OrderDate = DateTime.Now.AddDays(i),
				ShipName = "ShipName " + i,
				ShipCity = "ShipCity " + i
			});

			return Json(result.ToDataSourceResult(request));
		}

		//public ActionResult ReportView_Read([DataSourceRequest] DataSourceRequest request)
		//{
		//	var result = Enumerable.Range(0, 50).Select(i => new ReportViewModel
		//	{
		//		CompanyName = "Company Name " + i,
		//		ContactName = "Contact Name " + i,
		//		ContactTitle = "Contact Title " + i,
		//		Country = "Coutry " + i
		//	});

		//	var dsResult = result.ToDataSourceResult(request);
		//	return Json(dsResult);
		//}


		//public IActionResult Personal_Read([DataSourceRequest] DataSourceRequest request)
  //      {
		//	using (var regEnt = new regEntContext())
  //          {
		//		IQueryable<>
  //          }

  //      }
	}
}
