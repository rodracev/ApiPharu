using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPharu.Model;

namespace ApiPharu.Data
{
    public class Bc365: DbContext
    {
        public Bc365 (DbContextOptions<Bc365> options) : base(options) { }
        public DbSet<PharuInv> PharuInvs { get; set; }
         public DbSet<PharuMov> PharuMovs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<PharuInv>()
            .HasKey(p => new { p.SiteID, p.InvtID }); // Definir clave compuesta
            modelBuilder.Entity<PharuMov>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        } 
    }
}