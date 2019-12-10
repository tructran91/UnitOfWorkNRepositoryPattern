using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitOfWorkNRepositoryPattern.Data.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    DirectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "DirectorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Steven", "Spielberg" },
                    { 2, "James", "Cameron" },
                    { 3, "Martin", "Scorsese" },
                    { 4, "Quentin", "Tarantino" },
                    { 5, "Christopher", "Nolan" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Hành động" },
                    { 2, "Hoạt hình" },
                    { 3, "Adult" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "DirectorId", "GenreId", "Language", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "English", 5, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(677), "Nhà tù Shawshank (The Shawshank Redemption)" },
                    { 2, 1, 1, "Vietnamese", 5, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6718), "Bố già (The Godfather)" },
                    { 3, 2, 1, "Vietnamese", 4, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6780), "Bố già phần II (The Godfather Part II)" },
                    { 8, 5, 1, "English", 3, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6791), "Chuyện Tào Lao (Pulp Fiction)" },
                    { 10, 5, 1, "English", 5, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6844), "Sàn đấu sinh tử (Fight Club)" },
                    { 4, 2, 2, "Vietnamese", 5, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6780), "Kỵ sĩ bóng đêm (The Dark Knight)" },
                    { 5, 3, 2, "Vietnamese", 3, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6780), "12 người đàn ông giận dữ (12 Angry Men)" },
                    { 9, 5, 2, "English", 5, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6840), "Thiện, ác, tà (The Good, the Bad and the Ugly)" },
                    { 6, 3, 3, "Vietnamese", 3, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6780), "Bản danh sách của Schindler (Schindler's List)" },
                    { 7, 4, 3, "Vietnamese", 4, new DateTime(2019, 11, 28, 16, 29, 43, 915, DateTimeKind.Local).AddTicks(6783), "Chúa tể những chiếc nhẫn: Sự trở lại của nhà vua (Lord of the Rings: The Return of the King)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
