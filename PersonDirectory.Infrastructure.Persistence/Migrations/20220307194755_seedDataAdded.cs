using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectory.Infrastructure.Persistence.Migrations
{
    public partial class seedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Common",
                table: "City",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "DeleteDate", "DeletedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7544), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), null, "ქუთაისი" });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "City",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "DeleteDate", "DeletedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 2, new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7560), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), null, "თბილისი" });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "City",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "DeleteDate", "DeletedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 3, new DateTime(2022, 3, 7, 23, 47, 55, 311, DateTimeKind.Local).AddTicks(7562), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), null, "ბათუმი" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Common",
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "City",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
