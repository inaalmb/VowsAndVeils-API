using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VowsAndVeils.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWeddingDress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "WeddingDresses",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "DressLength",
                table: "WeddingDresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DressLength",
                table: "WeddingDresses");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "WeddingDresses",
                newName: "Type");
        }
    }
}
