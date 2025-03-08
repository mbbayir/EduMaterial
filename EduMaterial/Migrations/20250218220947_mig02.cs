using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMaterial.Migrations
{
    /// <inheritdoc />
    public partial class mig02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de783645-3f6d-43af-87d8-895da9bcbfb8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcf83762-a564-45c8-9207-237747a94602", 0, "76e78297-0edd-4af5-9aef-f56566bea07e", "admin@example.com", true, "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL25oMHHu2B3FR3mdRgWIAIt4s2AWd3bMOqd6nFkZUhDhy6Y2SFUHM2l78yXna9/1Q==", null, false, "", false, "admin@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcf83762-a564-45c8-9207-237747a94602");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de783645-3f6d-43af-87d8-895da9bcbfb8", 0, "5efcd341-a337-4522-abe2-def19a0c63a8", "admin@example.com", true, "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMBLrTCC/KO2lLWZWWGbO7rVwBiOfZxfaeNgXSl+QhvPV78EWyMWHjwx8CbyErJX8g==", null, false, "", false, "admin@example.com" });
        }
    }
}
