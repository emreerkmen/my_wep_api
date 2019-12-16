using Microsoft.EntityFrameworkCore;
using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
