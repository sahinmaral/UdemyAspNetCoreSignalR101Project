using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccess.Migrations
{
    public partial class update_discount_of_day_seed_data_image_url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/feane/images/o1.jpg");

            migrationBuilder.UpdateData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Title" },
                values: new object[] { "/feane/images/o2.jpg", "Pizza Günleri" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/feane/images/o1.jpg");

            migrationBuilder.UpdateData(
                table: "DiscountOfDays",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Title" },
                values: new object[] { "~/feane/images/o2.jpg", "Pizza Günleri  " });
        }
    }
}
