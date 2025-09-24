using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lamazon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Key", "Name" },
                values: new object[,]
                {
                    { "admin", "Administrator" },
                    { "user", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "RoleKey" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "Admin User", "AQAAAAEAACcQAAAAECJCSH7Y7+DSAD+UKEnb6fjgOROzppnUpop5/kVMcBDjzOVaLz0vts978iw4ooBhhQ==", "admin" },
                    { 2, "user@user.com", "User", "AQAAAAEAACcQAAAAEH2PV/R1HciXgHqwrYcEp/32IrxaQ44wcbBnM6EHK2FXA5wZRYXN6pddtVKNqTpTxg==", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Key",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Key",
                keyValue: "user");
        }
    }
}
