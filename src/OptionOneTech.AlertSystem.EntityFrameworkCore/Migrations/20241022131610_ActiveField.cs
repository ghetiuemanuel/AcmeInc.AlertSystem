using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptionOneTech.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class ActiveField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AppRules",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "AppRules",
                newName: "IsActive");
        }
    }
}
