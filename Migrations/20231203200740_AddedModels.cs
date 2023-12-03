using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tp4.Migrations
{
    /// <inheritdoc />
    public partial class AddedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Movies_MoviesId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "Role",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_MoviesId",
                table: "Role",
                newName: "IX_Role_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Movie_Added",
                table: "movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "file",
                table: "movies",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "membershiptypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFee = table.Column<double>(type: "float", nullable: false),
                    DurationInMonth = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membershiptypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membershiptype_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_membershiptypes_membershiptype_id",
                        column: x => x.membershiptype_id,
                        principalTable: "membershiptypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "GenreFromJsonFile1" },
                    { 2, "GenreFromJsonFile2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CustomersId",
                table: "movies",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_genre_id",
                table: "movies",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_membershiptype_id",
                table: "customers",
                column: "membershiptype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_customers_CustomersId",
                table: "movies",
                column: "CustomersId",
                principalTable: "customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_genre_id",
                table: "movies",
                column: "genre_id",
                principalTable: "genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_movies_MovieId",
                table: "Role",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_customers_CustomersId",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_genre_id",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_movies_MovieId",
                table: "Role");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "membershiptypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_CustomersId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_genre_id",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "Movie_Added",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "file",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "movies");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Roles",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_MovieId",
                table: "Roles",
                newName: "IX_Roles_MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Movies_MoviesId",
                table: "Roles",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
