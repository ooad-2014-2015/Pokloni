﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pokloni.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ajdin_connection : DbContext
    {
        public ajdin_connection()
            : base("name=ajdin_connection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblKomentar> tblKomentar { get; set; }
        public DbSet<tblKupac> tblKupac { get; set; }
        public DbSet<tblOsoba> tblOsoba { get; set; }
        public DbSet<tblPoklon> tblPoklon { get; set; }
        public DbSet<tblPoslovnica> tblPoslovnica { get; set; }
        public DbSet<tblProdavač> tblProdavač { get; set; }
        public DbSet<tblProizvodjac> tblProizvodjac { get; set; }
        public DbSet<tblUposlenik> tblUposlenik { get; set; }
        public DbSet<tblZahtjev> tblZahtjev { get; set; }
    }
}
