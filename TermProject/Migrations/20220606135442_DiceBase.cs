using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class DiceBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Full_Name = table.Column<string>(type: "TEXT", nullable: true),
                    ACC_Creation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Employee_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Employed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Product_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Product_Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    SellingSince = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientsID = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeesID = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientsID",
                        column: x => x.ClientsID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdersID = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductsID = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrdersID",
                        column: x => x.OrdersID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersID",
                table: "OrderItems",
                column: "OrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductsID",
                table: "OrderItems",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientsID",
                table: "Orders",
                column: "ClientsID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeesID",
                table: "Orders",
                column: "EmployeesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
