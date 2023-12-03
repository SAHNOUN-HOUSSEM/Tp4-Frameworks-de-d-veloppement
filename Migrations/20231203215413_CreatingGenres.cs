using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tp4.Migrations
{
    /// <inheritdoc />
    public partial class CreatingGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreName",
                value: "Thriller");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreName",
                value: "Action");

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 3, "Comedy" },
                    { 4, "Adventure" },
                    { 5, "Horror" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreName",
                value: "GenreFromJsonFile1");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreName",
                value: "GenreFromJsonFile2");
        }
    }
}
