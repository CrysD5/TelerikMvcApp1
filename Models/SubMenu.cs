using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class SubMenu
    {
        public partial class RosterReports
        {
            public string RostReport { get; set; }
            public int? rostRepId { get; set; }
            public List<Blocks> Blocks { get; set; }
            //public Blocks Blocks { get; set; }
            public int? parentId { get; set; }

        }

        public partial class Blocks
        {
            public string blockNo { get; set; }
            public int? blockId { get; set; }
            public RosterReports RosterReports { get; set; }

        }

        //public partial class IndividualReports
        //{
        //    public string studName { get; set; }
        //    [Display(Name = "Individual Student Data: ")]
        //    public string iReport { get; set; }
        //    public int? indRepId { get; set; }
        //    public int? parentId { get; set; }
        //}
    }

}
