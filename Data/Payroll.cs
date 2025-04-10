using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPharu.Model;
using ApiPharu.Model.Personas;
namespace ApiPharu.Data
{
    public class Payroll: DbContext
    {
        public Payroll (DbContextOptions<Payroll> options) : base(options) { }
        public DbSet<Consultarut> Consultaruts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultarut>().ToTable("VW_CONSULTARUT");
            base.OnModelCreating(modelBuilder);
        } 
    }
}