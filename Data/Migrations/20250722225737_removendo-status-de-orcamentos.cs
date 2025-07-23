using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class removendostatusdeorcamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoHora_status_StatusId",
                table: "OrcamentoHora");

            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoPorProjeto_status_StatusId",
                table: "OrcamentoPorProjeto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoHora_status_StatusId",
                table: "OrcamentoHora");

            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoPorProjeto_status_StatusId",
                table: "OrcamentoPorProjeto");
         
        }
    }
}
