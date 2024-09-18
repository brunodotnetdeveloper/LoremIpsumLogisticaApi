using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoremIpsumLogistica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCollumnTypeToAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "addresses",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "addresses");
        }
    }
}
