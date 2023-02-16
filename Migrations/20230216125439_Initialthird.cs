using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLibrary.Migrations
{
    public partial class Initialthird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminAuthor_AdminAuthor_AdminBookId",
                table: "AdminAuthor");

            migrationBuilder.DropTable(
                name: "AdminGenre");

            migrationBuilder.DropIndex(
                name: "IX_AdminBook_AdminAuthorID",
                table: "AdminBook");

            migrationBuilder.DropIndex(
                name: "IX_AdminAuthor_AdminBookId",
                table: "AdminAuthor");

            migrationBuilder.DropColumn(
                name: "AdminBookId",
                table: "AdminAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_AdminBook_AdminAuthorID",
                table: "AdminBook",
                column: "AdminAuthorID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdminBook_AdminAuthorID",
                table: "AdminBook");

            migrationBuilder.AddColumn<int>(
                name: "AdminBookId",
                table: "AdminAuthor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdminGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminBookId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminGenre_AdminBook_AdminBookId",
                        column: x => x.AdminBookId,
                        principalTable: "AdminBook",
                        principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminBook_AdminAuthorID",
                table: "AdminBook",
                column: "AdminAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAuthor_AdminBookId",
                table: "AdminAuthor",
                column: "AdminBookId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminGenre_AdminBookId",
                table: "AdminGenre",
                column: "AdminBookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAuthor_AdminAuthor_AdminBookId",
                table: "AdminAuthor",
                column: "AdminBookId",
                principalTable: "AdminAuthor",
                principalColumn: "Id",
                //onDelete: ReferentialAction.Cascade);
        onDelete: ReferentialAction.NoAction);
        }
    }
}
