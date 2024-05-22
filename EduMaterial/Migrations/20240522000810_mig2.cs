using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMaterial.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "044d6e68-de97-4952-9b65-90e278ea4e67");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "Producers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "CategoryCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditingDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "45533744-d405-4727-8c64-f4ebcc1fe96b", 0, "13f5395b-7757-4737-8fd3-72a8cfad7b93", "admin@example.com", true, "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHpkYpthQ/fmWSyWJcmRC1Cw6WQlhYPJLrUSD9K0dV3jFN3cldsnYQCFrCgotxiCVA==", null, false, "", false, "admin@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45533744-d405-4727-8c64-f4ebcc1fe96b");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "CategoryCourses");

            migrationBuilder.DropColumn(
                name: "EditingDate",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "044d6e68-de97-4952-9b65-90e278ea4e67", 0, "876820d9-0d5e-440a-904d-bb0b1187c38c", "admin@example.com", true, "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGRTEn3Of7AGavLroZcDtacWoSY5gRfc3xSptCjFbr56JIjiRSnT/N7LceorpliV9g==", null, false, "", false, "admin@example.com" });
        }
    }
}
