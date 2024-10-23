using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptionOneTech.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TriggerRequired",
                table: "AppRules",
                newName: "TriggersRequired");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TriggerTimestamp",
                table: "AppRules",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TriggersRequired",
                table: "AppRules",
                newName: "TriggerRequired");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TriggerTimestamp",
                table: "AppRules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
