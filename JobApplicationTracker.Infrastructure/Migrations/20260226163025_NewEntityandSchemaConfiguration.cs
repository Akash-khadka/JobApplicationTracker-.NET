using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewEntityandSchemaConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Company_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Comapnies");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 2, 26, 16, 30, 25, 15, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Comapnies",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Comapnies",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Comapnies",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyInfo",
                table: "Comapnies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comapnies",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comapnies_Email",
                table: "Comapnies",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Comapnies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Comapnies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Comapnies_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comapnies",
                table: "Comapnies");

            migrationBuilder.DropIndex(
                name: "IX_Comapnies_Email",
                table: "Comapnies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Comapnies");

            migrationBuilder.DropColumn(
                name: "CompanyInfo",
                table: "Comapnies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comapnies");

            migrationBuilder.RenameTable(
                name: "Comapnies",
                newName: "Company");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Company_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
