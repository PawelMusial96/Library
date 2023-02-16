using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLibrary.Migrations
{
    public partial class Initialfirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminAuthor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAuthor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminAuthor_AdminAuthor_AdminBookId",
                        column: x => x.AdminBookId,
                        principalTable: "AdminAuthor",
                        principalColumn: "Id",
                                //onDelete: ReferentialAction.Cascade);
                                onDelete: ReferentialAction.NoAction);

                });

            migrationBuilder.CreateTable(
                name: "AdminBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminAuthorID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminBook_AdminAuthor_AdminAuthorID",
                        column: x => x.AdminAuthorID,
                        principalTable: "AdminAuthor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "AdminGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminBookId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_AdminAuthor_AdminBookId",
                table: "AdminAuthor",
                column: "AdminBookId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminBook_AdminAuthorID",
                table: "AdminBook",
                column: "AdminAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminGenre_AdminBookId",
                table: "AdminGenre",
                column: "AdminBookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminGenre");

            migrationBuilder.DropTable(
                name: "AdminBook");

            migrationBuilder.DropTable(
                name: "AdminAuthor");
        }
    }
}
