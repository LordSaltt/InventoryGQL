using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphqlServer.Data.Migrations
{
    public partial class AddingUserToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Products_ProductId",
                table: "SupplierProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierProduct",
                table: "SupplierProduct");

            migrationBuilder.RenameTable(
                name: "SupplierProduct",
                newName: "SupplierProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProduct_SupplierId",
                table: "SupplierProducts",
                newName: "IX_SupplierProducts_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProduct_ProductId",
                table: "SupplierProducts",
                newName: "IX_SupplierProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierProducts",
                table: "SupplierProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSaltt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProducts_Products_ProductId",
                table: "SupplierProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProducts_Suppliers_SupplierId",
                table: "SupplierProducts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProducts_Products_ProductId",
                table: "SupplierProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProducts_Suppliers_SupplierId",
                table: "SupplierProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierProducts",
                table: "SupplierProducts");

            migrationBuilder.RenameTable(
                name: "SupplierProducts",
                newName: "SupplierProduct");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProducts_SupplierId",
                table: "SupplierProduct",
                newName: "IX_SupplierProduct_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProducts_ProductId",
                table: "SupplierProduct",
                newName: "IX_SupplierProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierProduct",
                table: "SupplierProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Products_ProductId",
                table: "SupplierProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
