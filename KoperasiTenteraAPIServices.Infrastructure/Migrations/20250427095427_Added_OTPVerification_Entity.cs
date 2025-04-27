using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoperasiTenteraAPIServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_OTPVerification_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhoneVerified",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CustomerOtpVerifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OtpCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOtpVerifications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOtpVerifications");

            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsPhoneVerified",
                table: "Customers");
        }
    }
}
