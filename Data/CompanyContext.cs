using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class CompanyContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PassportInfo> PassportInfos { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Database=Company7;Integrated Security=true")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.FirstName).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Employee>().Navigation(x => x.PassportInfo).AutoInclude();

            //modelBuilder.Entity<Employee>().HasData(new Employee { });

            base.OnModelCreating(modelBuilder);
        }
    }
}
