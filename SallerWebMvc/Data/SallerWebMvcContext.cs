using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SallerWebMvc.Models;

namespace SallerWebMvc.Data
{
    public class SallerWebMvcContext : DbContext
    {
        public SallerWebMvcContext (DbContextOptions<SallerWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
