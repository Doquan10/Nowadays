
using Microsoft.EntityFrameworkCore;
using Nowadays.Entity.Concrete;
using System.Reflection;

namespace Nowadays.DAL.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                        .HasKey(pt => new { pt.EmployeeId, pt.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(pt => pt.Employee)
                        .WithMany(p => p.EmployeeProjects)
                        .HasForeignKey(pt => pt.EmployeeId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(pt => pt.Project)
                        .WithMany(p => p.EmployeeProjects)
                        .HasForeignKey(pt => pt.ProjectId)
                        .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<IssueEmployee>()
                       .HasKey(pt => new { pt.EmployeeId, pt.IssueId });

            modelBuilder.Entity<IssueEmployee>().HasOne(pt => pt.Issue)
                        .WithMany(p => p.IssueEmployees)
                        .HasForeignKey(pt => pt.IssueId)
                         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IssueEmployee>().HasOne(pt => pt.Employee)
                        .WithMany(p => p.IssueEmployees)
                        .HasForeignKey(pt => pt.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        //DbSets
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueEmployee> IssueEmployees { get; set; }

    }
}
