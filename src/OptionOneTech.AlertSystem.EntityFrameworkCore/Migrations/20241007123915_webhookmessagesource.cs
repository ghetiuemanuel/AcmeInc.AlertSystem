using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptionOneTech.AlertSystem.Migrations
{
    /// <inheritdoc />
    public partial class webhookmessagesource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AppWebhookMessageSources",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "AppWebhookMessageSources");
        }
    }
}
