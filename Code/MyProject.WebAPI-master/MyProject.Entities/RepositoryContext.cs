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
        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }
        public DbSet<IndentProducts> IndentProducts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<ParkingCharges> ParkingCharges { get; set; }
        public DbSet<ChargesTypeMaster> ChargesTypeMaster { get; set; }
        public DbSet<VehicleTypeMaster> VehicleTypeMaster { get; set; }
    }
}
