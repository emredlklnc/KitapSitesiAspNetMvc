﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace site1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KitapSitesiEntities : DbContext
    {
        public KitapSitesiEntities()
            : base("name=KitapSitesiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kitaplar> Kitaplar { get; set; }
        public virtual DbSet<Kullanıcılar> Kullanıcılar { get; set; }
        public virtual DbSet<BilimKurgu> BilimKurgu { get; set; }
        public virtual DbSet<EnCokSatılanlar> EnCokSatılanlar { get; set; }
        public virtual DbSet<Macera> Macera { get; set; }
        public virtual DbSet<Romantik> Romantik { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Komedi> Komedi { get; set; }
        public virtual DbSet<KisiselGelisim> KisiselGelisim { get; set; }
        public virtual DbSet<TemelEserler> TemelEserler { get; set; }
        public virtual DbSet<Sepetim> Sepetim { get; set; }
        public virtual DbSet<EnYeniGelenler> EnYeniGelenler { get; set; }
    }
}
