using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaLetsCode.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "A" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "B" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "C" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Ano", "Autor", "CategoriaId", "Editora", "Nome" },
                values: new object[] { 1, 2021, "B", 1, "C", "A" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Ano", "Autor", "CategoriaId", "Editora", "Nome" },
                values: new object[] { 2, 2022, "BB", 2, "CB", "AB" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Ano", "Autor", "CategoriaId", "Editora", "Nome" },
                values: new object[] { 3, 2023, "BC", 3, "CC", "AC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
