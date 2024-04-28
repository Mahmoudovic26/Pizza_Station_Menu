using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class addedepp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "https://sp-ao.shortpixel.ai/client/to_webp,q_lossless,ret_img,w_509/https://distinctivecatering.net/wp-content/uploads/2024/01/Pepperoni-Pizza.jpg", "Pepperoni", 12.5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Cheese" },
                    { 4, "Pepperoni" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
