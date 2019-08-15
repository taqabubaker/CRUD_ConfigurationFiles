using CRUD.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
