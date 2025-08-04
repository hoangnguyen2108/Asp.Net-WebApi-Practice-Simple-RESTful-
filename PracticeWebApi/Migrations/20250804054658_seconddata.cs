using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class seconddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Productid", "Category", "Name", "Price" },
                values: new object[] { 2, "Category2", "Name2", 15 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Productid",
                keyValue: 2);
        }
    }
}
