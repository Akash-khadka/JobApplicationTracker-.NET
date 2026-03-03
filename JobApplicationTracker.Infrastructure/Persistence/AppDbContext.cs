using JobApplicationTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

                entity.Property(j => j.JobTitle)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(j => j.Salary)
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

                entity.Property(j => j.CreatedDate)
                .HasDefaultValue(DateTime.Now);

                entity.Property(j => j.Location)
                .IsRequired()
                .HasMaxLength(225);
                
            });

       

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(c => c.Email)
                .IsUnique();

                entity.Property(c => c.Contact)
                .IsRequired()
                .HasMaxLength(14);

                entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(225);

                entity.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(225);

                entity.Property(c => c.Address)
                .HasMaxLength(225);

                entity.Property(c => c.IsActive)
                .HasDefaultValue(true); //0 is true and 1 is false
                
            });
           
        }
    }
}
