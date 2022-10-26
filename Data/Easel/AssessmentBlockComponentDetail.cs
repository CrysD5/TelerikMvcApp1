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
    
    public partial class AssessmentBlockComponentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentBlockComponentDetail()
        {
            this.AssessmentBlockComponents = new HashSet<AssessmentBlockComponent>();
            this.AssessmentBlockComponentDetail1 = new HashSet<AssessmentBlockComponentDetail>();
            this.AssessmentBlockComponentStudents = new HashSet<AssessmentBlockComponentStudent>();
        }
    
        public int id { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string code { get; set; }
        public string subcode { get; set; }
        public string name { get; set; }
        public string othername { get; set; }
        public Nullable<bool> ismanual { get; set; }
        public Nullable<bool> isattendance { get; set; }
        public string gradesource { get; set; }
        public Nullable<int> sequence { get; set; }
        public Nullable<bool> issubcomponent { get; set; }
        public Nullable<bool> issourcedata { get; set; }
        public Nullable<bool> active { get; set; }
        public string userlogin { get; set; }
        public Nullable<System.DateTime> userdate { get; set; }
        public string asscomp_old { get; set; }
        public string asssubcomp_old { get; set; }
        public string asscompname_old { get; set; }
        public string asssubcompname_old { get; set; }
        public string manual_update_old { get; set; }
        public string attendance_old { get; set; }
        public string subcomp_old { get; set; }
        public string source_data_old { get; set; }
        public Nullable<int> sort_num_old { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentBlockComponent> AssessmentBlockComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentBlockComponentDetail> AssessmentBlockComponentDetail1 { get; set; }
        public virtual AssessmentBlockComponentDetail AssessmentBlockComponentDetail2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentBlockComponentStudent> AssessmentBlockComponentStudents { get; set; }
    }
}
