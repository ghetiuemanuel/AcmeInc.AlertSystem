using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmeInc.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class ruleNotificationemails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificationEmails",
                table: "AppRules",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "NotificationSent",
                table: "AppAlerts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationEmails",
                table: "AppRules");

            migrationBuilder.DropColumn(
                name: "NotificationSent",
                table: "AppAlerts");
        }
    }
}
