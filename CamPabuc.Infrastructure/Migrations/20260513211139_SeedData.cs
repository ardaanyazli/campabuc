using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CamPabuc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Address", "CreatedAt", "IsActive", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1 Bowerman Dr, Beaverton, OR", new DateOnly(2026, 5, 14), true, "Nike", "555-0100", new DateOnly(2026, 5, 14) },
                    { 2, "Adi-Dassler-Straße 1, Herzogenaurach", new DateOnly(2026, 5, 14), true, "Adidas", "555-0200", new DateOnly(2026, 5, 14) },
                    { 3, "Puma Way 1, Herzogenaurach", new DateOnly(2026, 5, 14), true, "Puma", "555-0300", new DateOnly(2026, 5, 14) }
                });

            migrationBuilder.InsertData(
                table: "ShoeCategories",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateOnly(2026, 5, 14), true, "Running", new DateOnly(2026, 5, 14) },
                    { 2, new DateOnly(2026, 5, 14), true, "Casual", new DateOnly(2026, 5, 14) },
                    { 3, new DateOnly(2026, 5, 14), true, "Formal", new DateOnly(2026, 5, 14) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoeCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
