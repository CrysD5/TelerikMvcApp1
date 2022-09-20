using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TelerikMvcApp1.Models
{
    public class ReportViewModel
    {
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string ContactTitle { get; set; }
    }
}
