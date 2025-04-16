using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"), new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local), null, false, "Test Department", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DepartmentId", "Email", "FirstName", "IsDeleted", "LastName", "UpdatedAt" },
                values: new object[] { new Guid("a1759505-2118-47f1-9f77-1a7b9c6a49c4"), new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local), null, new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"), "admin@taskmanagementsystem.com", "Admin", false, "User", null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedDepartmentId", "CreatedAt", "CreatedById", "DeletedAt", "Description", "IsDeleted", "Status", "StatusChangedAt", "Title", "UpdatedAt" },
                values: new object[] { new Guid("a7f8ae2f-5adb-46b7-a6b9-cf2af668ff2c"), new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"), new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local), new Guid("a1759505-2118-47f1-9f77-1a7b9c6a49c4"), null, "Test description", false, 0, new DateTime(2025, 4, 16, 15, 50, 46, 495, DateTimeKind.Local).AddTicks(5057), "Test title", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a7f8ae2f-5adb-46b7-a6b9-cf2af668ff2c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1759505-2118-47f1-9f77-1a7b9c6a49c4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"));
        }
    }
}
