using JobApplicationTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Job> Job { get; set; }
        public DbSet<Company> Company { get; set; }

        //schema configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasOne(c => c.Company)
                .WithMany(j => j.Jobs)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(p => p.JobTitle)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(p => p.Salary)
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

                entity.Property(p => p.CreatedDate)
                .HasDefaultValue(DateTime.Now);

                entity.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(225);
                
            });

       

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(c => c.Email)
                .IsUnique();

                entity.Property(p => p.Contact)
                .IsRequired()
                .HasMaxLength(14);

                entity.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(225);

                entity.Property(p => p.CompanyName)
                .IsRequired()
                .HasMaxLength(225);

                entity.Property(p => p.Address)
                .HasMaxLength(225);
                
            });
           
        }
    }
}
