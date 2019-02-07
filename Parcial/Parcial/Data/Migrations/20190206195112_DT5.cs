using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Parcial.Data.Migrations
{
    public partial class DT5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 13, nullable: false),
                    Cedula = table.Column<string>(maxLength: 13, nullable: false),
                    Celular = table.Column<string>(maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 13, nullable: false),
                    Nombre = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
