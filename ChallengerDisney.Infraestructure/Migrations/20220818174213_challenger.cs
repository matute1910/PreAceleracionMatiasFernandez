using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengerDisney.Infraestructure.Migrations
{
    public partial class challenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieOrSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOrSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieOrSeries_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovieOrSeries",
                columns: table => new
                {
                    ListOfCharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesOrAssociatedSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovieOrSeries", x => new { x.ListOfCharactersId, x.MoviesOrAssociatedSeriesId });
                    table.ForeignKey(
                        name: "FK_CharacterMovieOrSeries_Character_ListOfCharactersId",
                        column: x => x.ListOfCharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovieOrSeries_MovieOrSeries_MoviesOrAssociatedSeriesId",
                        column: x => x.MoviesOrAssociatedSeriesId,
                        principalTable: "MovieOrSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovieOrSeries_MoviesOrAssociatedSeriesId",
                table: "CharacterMovieOrSeries",
                column: "MoviesOrAssociatedSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieOrSeries_GenderId",
                table: "MovieOrSeries",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovieOrSeries");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "MovieOrSeries");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
