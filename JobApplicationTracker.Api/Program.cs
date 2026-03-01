
using JobApplicationTracker.Infrastructure.IoC;
using JobApplicationTracker.Infrastructure.Persistence;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
log4net.Util.LogLog.InternalDebugging = true;//for internal debugging


EnsureLogsTable(builder.Configuration.GetConnectionString("DefaultConnection"));

var logReposiroty = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logReposiroty, new FileInfo("log4net.config"));

//di
builder.Services.GetDependencyServices();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("JobApplicationTracker.Infrastructure")
        );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void EnsureLogsTable(string connectionString)
{
    using var connection = new SqlConnection(connectionString);
    connection.Open();

    string createTableSql = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name= 'LOGSTABLE' AND xtype='U')
    BEGIN
        CREATE TABLE LOGSTABLE (
            Id INT IDENTITY(1,1) PRIMARY KEY,
            LogDate DATETIME2 NOT NULL,
            Thread NVARCHAR(225) NULL,
            LogLevel NVARCHAR(50) NULL,
            Logger NVARCHAR(225) NULL,
            LogMessage NVARCHAR(MAX) NULL,
            Exception NVARCHAR(MAX) NULL
        )
    END";

    using var command = new SqlCommand(createTableSql, connection);
    command.ExecuteNonQuery(); 
}