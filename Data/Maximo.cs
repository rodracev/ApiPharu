using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPharu.Model;
namespace ApiPharu.Data
{
    public class Maximo: DbContext
    {
        public Maximo (DbContextOptions<Maximo> options) : base(options) { }
        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}