using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Comapnies_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Comapnies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyId",
                table: "Job",
                newName: "IX_Job_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Comapnies_Email",
                table: "Company",
                newName: "IX_Company_Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 26, 16, 56, 15, 195, DateTimeKind.Local).AddTicks(7608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 2, 26, 16, 30, 25, 15, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Comapnies");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_Email",
                table: "Comapnies",
                newName: "IX_Comapnies_Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 26, 16, 30, 25, 15, DateTimeKind.Local).AddTicks(3716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 2, 26, 16, 56, 15, 195, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Comapnies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Comapnies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
