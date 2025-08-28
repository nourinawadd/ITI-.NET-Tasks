using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Final_Project
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=NOURINS-DESKTOP\\SQLEXPRESS;Database=ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many Employee ↔ Project
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(p => p.Employees);
        }
    }
}
