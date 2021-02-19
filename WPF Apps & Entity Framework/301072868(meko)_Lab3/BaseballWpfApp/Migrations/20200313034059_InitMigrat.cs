using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseballWpfApp.Migrations
{
    public partial class InitMigrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorISBN",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorISBN", x => new { x.AuthorID, x.ISBN });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorISBN");
        }
    }
}
