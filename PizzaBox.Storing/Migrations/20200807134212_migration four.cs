using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrationfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreId",
                table: "Users",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Store_StoreId",
                table: "Users",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Store_StoreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StoreId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Users");
        }
    }
}
