using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrationseven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrderId",
                table: "Users",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserModelId",
                table: "Orders",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserModelId",
                table: "Orders",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserModelId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Orders");
        }
    }
}
