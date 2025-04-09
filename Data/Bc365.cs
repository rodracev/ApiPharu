using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPharu.Model;
using ApiPharu.Model.Compras;

namespace ApiPharu.Data
{
    public class Bc365: DbContext
    {
        public Bc365 (DbContextOptions<Bc365> options) : base(options) { }
        public DbSet<PharuInv> PharuInvs { get; set; }
         public DbSet<PharuMov> PharuMovs { get; set; }
        public DbSet<PharuPM> PharuPMs { get; set; }
        public DbSet<PurOrdDet> PurOrdDets { get; set; }
        public DbSet<PurchOrd> PurchOrds { get; set; }
        public DbSet<POTran> POTrans { get; set; }
         public DbSet<Inventory> Inventorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<PharuInv>()
            .HasKey(p => new { p.SiteID, p.InvtID }); // Definir clave compuesta
            modelBuilder.Entity<PharuMov>().HasNoKey();
            modelBuilder.Entity<PurOrdDet>().HasNoKey();
            modelBuilder.Entity<PharuPM>() .HasKey(p => new { p.Documento, p.Articulo });;
            modelBuilder.Entity<PurchOrd>().HasKey(p => new {p.PONbr});
            modelBuilder.Entity<POTran>().HasNoKey();
            modelBuilder.Entity<Inventory>().HasKey(p => new {p.InvtID});


            base.OnModelCreating(modelBuilder);
        } 
    }
}