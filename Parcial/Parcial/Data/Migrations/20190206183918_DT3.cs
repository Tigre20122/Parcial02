using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Parcial.Data.Migrations
{
    public partial class DT3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCaducaion = table.Column<string>(nullable: false),
                    FechaFabricacion = table.Column<string>(nullable: false),
                    IdProvedor = table.Column<int>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    PrecioPublico = table.Column<double>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Provedor_IdProvedor",
                        column: x => x.IdProvedor,
                        principalTable: "Provedor",
                        principalColumn: "IdProvedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProvedor",
                table: "Producto",
                column: "IdProvedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
