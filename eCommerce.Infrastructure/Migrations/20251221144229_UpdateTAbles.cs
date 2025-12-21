using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTAbles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "063cca86-c503-48da-af9a-60f12830b2df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "882d62ff-93eb-4e29-b854-17951441f448");

            migrationBuilder.CreateTable(
                name: "Achives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73359bb4-022f-4a69-8cef-8b9e80519698", null, "Admin", "ADMIN" },
                    { "bb1ad7dc-3af6-4e72-9882-551aa2de6377", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("5b282512-53cb-438f-ab09-2372bdb24d05"), "Credet Cart" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achives");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73359bb4-022f-4a69-8cef-8b9e80519698");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb1ad7dc-3af6-4e72-9882-551aa2de6377");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "063cca86-c503-48da-af9a-60f12830b2df", null, "Admin", "ADMIN" },
                    { "882d62ff-93eb-4e29-b854-17951441f448", null, "User", "USER" }
                });
        }
    }
}
