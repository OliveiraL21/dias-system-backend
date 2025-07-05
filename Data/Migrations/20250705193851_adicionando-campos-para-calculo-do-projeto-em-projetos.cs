using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionandocamposparacalculodoprojetoemprojetos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<DateTime>(
                name: "TotalHoras",
                table: "Projetos",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalParcial",
                table: "Projetos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalProjeto",
                table: "Projetos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "TotalHoras",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ValorTotalParcial",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ValorTotalProjeto",
                table: "Projetos");

          
        }
    }
}
