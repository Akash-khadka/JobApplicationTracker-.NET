using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\jobapplicationtracker.api"))
                .AddJsonFile("appsettings.json")
                .Build();

            //get connection string by key
            string connectionstring = configuration.GetConnectionString("defaultconnection");

            var optionbuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionbuilder.UseSqlServer(connectionstring);

            return new AppDbContext(optionbuilder.Options);

            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseSqlServer("Server=INSPIRON5515\\SQLEXPRESS;Database=JOBAPPLICATIONDB;Trusted_Connection=True;TrustServerCertificate=True;")
            //    .Options;

            //return new AppDbContext(options);
        }
    }
}
