//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikMvcApp1.Data.Easel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssessmentBlockComponentStudent
    {
        public int id { get; set; }
        public Nullable<int> gyr { get; set; }
        public Nullable<int> somsectionblock_id { get; set; }
        public Nullable<int> assessmentblockcomponentdetail_id { get; set; }
        public string emaddr { get; set; }
        public Nullable<int> assessmentgradecode_id { get; set; }
        public int attempt { get; set; }
        public Nullable<bool> release { get; set; }
        public Nullable<System.DateTime> examdate { get; set; }
        public string userlogin { get; set; }
        public Nullable<System.DateTime> userdate { get; set; }
        public string seyear_old { get; set; }
        public Nullable<int> bcode_old { get; set; }
        public string asscomp_old { get; set; }
        public string asssubcomp_old { get; set; }
        public string release_old { get; set; }
        public string grade_old { get; set; }
    
        public virtual AssessmentBlockComponentDetail AssessmentBlockComponentDetail { get; set; }
        public virtual AssessmentGradeCode AssessmentGradeCode { get; set; }
    }
}