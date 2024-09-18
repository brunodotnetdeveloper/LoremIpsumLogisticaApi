using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoremIpsumLogistica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "uf",
                table: "addresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "addresses",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "addresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "addresses",
                newName: "complement");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "addresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "addresses",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "addresses",
                newName: "neighborhood");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "addresses",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "addresses",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "addresses",
                newName: "uf");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "addresses",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "neighborhood",
                table: "addresses",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "complement",
                table: "addresses",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "addresses",
                newName: "cidade");
        }
    }
}
