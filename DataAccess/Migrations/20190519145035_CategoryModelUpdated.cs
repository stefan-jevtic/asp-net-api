using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CategoryModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Dishes_DishId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DishId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DishId",
                table: "Categories",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Dishes_DishId",
                table: "Categories",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
