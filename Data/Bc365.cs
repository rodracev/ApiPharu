using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiPharu.Data
{
    public class Bc365: DbContext
    {
        public Bc365 (DbContextOptions<Bc365> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        } 
    }
}