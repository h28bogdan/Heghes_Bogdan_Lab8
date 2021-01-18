using Microsoft.EntityFrameworkCore.Migrations;

namespace Heghes_Bogdan_Lab8.Migrations
{
    public partial class BoardgameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Boardgame",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardgameID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardgameCategory_Boardgame_BoardgameID",
                        column: x => x.BoardgameID,
                        principalTable: "Boardgame",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boardgame_PublisherID",
                table: "Boardgame",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategory_BoardgameID",
                table: "BoardgameCategory",
                column: "BoardgameID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategory_CategoryID",
                table: "BoardgameCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Boardgame_Publisher_PublisherID",
                table: "Boardgame",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boardgame_Publisher_PublisherID",
                table: "Boardgame");

            migrationBuilder.DropTable(
                name: "BoardgameCategory");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Boardgame_PublisherID",
                table: "Boardgame");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Boardgame");
        }
    }
}
