﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikMvcApp1.Data.CanvasAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CanvasAPIEntities1 : DbContext
    {
        public CanvasAPIEntities1()
            : base("name=CanvasAPIEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<v_studentsAll> v_studentsAll { get; set; }
        public DbSet<v_StudentsSOM> v_StudentsSOM { get; set; }
        public DbSet<v_StudentsSOMwithReducedFee> v_StudentsSOMwithReducedFee { get; set; }
    }
}