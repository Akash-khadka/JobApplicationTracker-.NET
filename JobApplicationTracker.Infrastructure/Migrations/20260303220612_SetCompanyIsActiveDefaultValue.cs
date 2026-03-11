using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetCompanyIsActiveDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 3, 3, 22, 6, 11, 890, DateTimeKind.Local).AddTicks(6563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 3, 3, 21, 28, 41, 361, DateTimeKind.Local).AddTicks(6371));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 3, 3, 21, 28, 41, 361, DateTimeKind.Local).AddTicks(6371),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 3, 3, 22, 6, 11, 890, DateTimeKind.Local).AddTicks(6563));
        }
    }
}
