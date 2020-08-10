using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrationeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_ToppingModel_Pizzas_PizzaModelId",
                table: "ToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel");

            migrationBuilder.RenameTable(
                name: "ToppingModel",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "SizeModel",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "CrustModel",
                newName: "Crust");

            migrationBuilder.RenameIndex(
                name: "IX_ToppingModel_PizzaModelId",
                table: "Toppings",
                newName: "IX_Toppings_PizzaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crust",
                table: "Crust",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "Crust",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Size_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_PizzaModelId",
                table: "Toppings",
                column: "PizzaModelId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaModelId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crust",
                table: "Crust");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "ToppingModel");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "SizeModel");

            migrationBuilder.RenameTable(
                name: "Crust",
                newName: "CrustModel");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaModelId",
                table: "ToppingModel",
                newName: "IX_ToppingModel_PizzaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "CrustModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "SizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToppingModel_Pizzas_PizzaModelId",
                table: "ToppingModel",
                column: "PizzaModelId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
