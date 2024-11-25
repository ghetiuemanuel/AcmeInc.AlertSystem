using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmeInc.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class newFieldsInRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppRules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TriggerCount",
                table: "AppRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TriggerRequired",
                table: "AppRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TriggerTimestamp",
                table: "AppRules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TriggerWindowDuration",
                table: "AppRules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppRules");

            migrationBuilder.DropColumn(
                name: "TriggerCount",
                table: "AppRules");

            migrationBuilder.DropColumn(
                name: "TriggerRequired",
                table: "AppRules");

            migrationBuilder.DropColumn(
                name: "TriggerTimestamp",
                table: "AppRules");

            migrationBuilder.DropColumn(
                name: "TriggerWindowDuration",
                table: "AppRules");
        }
    }
}
