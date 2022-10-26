using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class DeanNotesModel
    {
        public int Id { get; set; }
        public int nid { get; set; }
        public string emaddr { get; set; }
        public DateTime edate { get; set; }
        public string adlogin { get; set; }
        public string etitle { get; set; }
        public string enotes { get; set; }
        public string notefile { get; set; }
    }
}