using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreNewDb.Migrations
{
    public partial class MaxLen2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MultiKey",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MultiKey");
        }
    }
}
