using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class FullSummaryViewModel
    {
        
        public string studentName { get; set; }
        public string studentID { get; set; }
        public string classYear { get; set; }
        public string societyName { get; set; }        
        public string subject { get; set; }
        public string hospitalID { get; set; }
        public int? BlockOne { get; set; }
        public int? BlockTwo { get; set; }
        public int? BlockThree { get; set; }
        public int? BlockFour { get; set; }
        public int? BlockFive { get; set; }
        public int? BlockSix { get; set; }
        
        public bool release { get; set; }




        //retry\
        public string finalGrade { get; set; }
        public int ID { get; set; }
        public string emaddr { get; set; }
        public int? somsectionblock_id { get; set; }
        public int? assessmentgradecode_id { get; set; }
        public int? id { get; set; }
        public string shortname { get; set; }
        public int? blkID { get; set; }
    }
}