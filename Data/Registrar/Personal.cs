namespace TelerikMvcApp1.Data.Registrar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        [Key]
        [StringLength(11)]
        public string Emplid { get; set; }

        [StringLength(30)]
        public string Last_Name { get; set; }

        [StringLength(30)]
        public string First_Name { get; set; }

        [StringLength(30)]
        public string Middle_Name { get; set; }

        [StringLength(50)]
        public string CW_PREF_LAST_NAME { get; set; }

        [StringLength(30)]
        public string CW_PREF_FIRST_NAME { get; set; }

        [StringLength(30)]
        public string CW_PREF_MID_NAME { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        [StringLength(3)]
        public string Visa_Permit_Type { get; set; }

        [StringLength(3)]
        public string BirthCountry { get; set; }

        [StringLength(3)]
        public string Citizen_Country { get; set; }

        [StringLength(55)]
        public string Address1 { get; set; }

        [StringLength(55)]
        public string Address2 { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string County { get; set; }

        [StringLength(6)]
        public string State { get; set; }

        [StringLength(12)]
        public string Postal { get; set; }

        [StringLength(3)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(6)]
        public string Extension { get; set; }

        [StringLength(55)]
        public string Address1_Other { get; set; }

        [StringLength(55)]
        public string Address2_Other { get; set; }

        [StringLength(30)]
        public string City_Other { get; set; }

        [StringLength(6)]
        public string State_Other { get; set; }

        [StringLength(12)]
        public string Postal_Other { get; set; }

        [StringLength(3)]
        public string Country_Other { get; set; }

        [StringLength(24)]
        public string CW_Phone_Other { get; set; }

        [StringLength(6)]
        public string CW_Extension { get; set; }

        [StringLength(70)]
        public string Email_Addr { get; set; }

        [StringLength(16)]
        public string Campus_Id { get; set; }

        [StringLength(24)]
        public string CW_CELL_PHONE { get; set; }

        [StringLength(50)]
        public string CW_CC_GIC_DESCR { get; set; }

        [StringLength(50)]
        public string CW_CC_PRONOUN_DESCR { get; set; }
    }
}
