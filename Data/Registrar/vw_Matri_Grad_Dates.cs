namespace TelerikMvcApp1.Data.Registrar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_Matri_Grad_Dates
    {
        public int id { get; set; }

        [Required]
        [StringLength(11)]
        public string Emplid { get; set; }

        [StringLength(16)]
        public string emaddr { get; set; }

        [StringLength(5)]
        public string Acad_Prog { get; set; }

        [StringLength(5)]
        public string campuscode { get; set; }

        [StringLength(4)]
        public string exp_grad_year { get; set; }

        [StringLength(4)]
        public string mdyr { get; set; }

        [StringLength(10)]
        public string mdt { get; set; }

        [StringLength(4)]
        public string gyr { get; set; }

        public DateTime? gdt { get; set; }

        public DateTime? Effdt { get; set; }

        [StringLength(10)]
        public string desk { get; set; }

        [StringLength(70)]
        public string advisor_name { get; set; }

        [StringLength(70)]
        public string advisor_email { get; set; }

        [StringLength(16)]
        public string advisor_campus_id { get; set; }

        [StringLength(4)]
        public string Prog_status { get; set; }

        public string dcode { get; set; }

        [StringLength(100)]
        public string ethnicity { get; set; }

        public string priordegrees { get; set; }

        [StringLength(4)]
        public string mstpprog_status { get; set; }

        [StringLength(50)]
        public string advisor_society { get; set; }
    }
}
