using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobReferenceNumber",
                table: "Jobs");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "JobReferenceNumber",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
