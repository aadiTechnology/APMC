using Microsoft.EntityFrameworkCore;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<StallDetails> StallDetails { get; set; }

        public DbSet<StallRegistration> StallRegistration { get; set; }

        public DbSet<StallProductCategories> StallProductCategories { get; set; }
        public DbSet<IndentDetails> IndentDetails { get; set; }


    }
}
