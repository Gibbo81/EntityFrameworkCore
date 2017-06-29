using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreNewDb.Migrations
{
    public partial class MultiKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultiKey",
                columns: table => new
                {
                    Session = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiKey", x => new { x.Session, x.Version });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiKey");
        }
    }
}
