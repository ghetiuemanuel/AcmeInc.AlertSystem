using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptionOneTech.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedprocessedfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedAt",
                table: "AppMessages",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedAt",
                table: "AppMessages");
        }
    }
}
