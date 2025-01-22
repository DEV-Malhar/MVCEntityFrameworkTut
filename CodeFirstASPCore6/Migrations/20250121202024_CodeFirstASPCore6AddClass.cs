using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstASPCore6.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstASPCore6AddClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StdStd",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StdStd",
                table: "Students");
        }
    }
}
