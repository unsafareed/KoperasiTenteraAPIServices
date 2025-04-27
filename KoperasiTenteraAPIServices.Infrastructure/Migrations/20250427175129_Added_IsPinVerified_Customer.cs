using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoperasiTenteraAPIServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_IsPinVerified_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPinVerified",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPinVerified",
                table: "Customers");
        }
    }
}
