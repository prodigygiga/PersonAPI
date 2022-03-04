using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectory.Infrastructure.Persistence.Migrations
{
    public partial class phoneNumberSchemaChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PhoneNumbers",
                newName: "PhoneNumbers",
                newSchema: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PhoneNumbers",
                schema: "Person",
                newName: "PhoneNumbers");
        }
    }
}
