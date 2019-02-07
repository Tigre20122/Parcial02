using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Parcial.Data.Migrations
{
    public partial class dt9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producto",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Facturas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdProducto",
                table: "Facturas",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Producto_IdProducto",
                table: "Facturas",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Producto_IdProducto",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_IdProducto",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Facturas");

            migrationBuilder.AddColumn<string>(
                name: "Producto",
                table: "Facturas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Facturas",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
