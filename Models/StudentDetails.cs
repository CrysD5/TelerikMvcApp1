using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public partial class StudentDetailClass
    {
        public string studentCaseID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PreferredFirstName { get; set; }
        public string StudentName { get; set; }
        //public string StudentName
        //{
        //    get
        //    {
        //        return this.LastName + ", " + (!String.IsNullOrEmpty(this.PreferredFirstName) ? this.PreferredFirstName : this.FirstName) + " " + (!String.IsNullOrEmpty(this.MiddleName) ? this.MiddleName.Substring(0, 1) : "");
        //    }
        //}
        public string SocietyDean { get; set; }
        public byte[] SmallStream { get; set; }
        public Guid? BigStream { get; set; }
        public string SmallPicture { get; set; }
        public string BigPicture { get; set; }
        public string Notes { get; set; }
    }
}