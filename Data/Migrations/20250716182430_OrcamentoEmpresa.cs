using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrcamentoEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "OrcamentoPorProjeto",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "OrcamentoHora",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoPorProjeto_StatusId",
                table: "OrcamentoPorProjeto",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoHora_StatusId",
                table: "OrcamentoHora",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoHora_status_StatusId",
                table: "OrcamentoHora",
                column: "StatusId",
                principalTable: "status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoPorProjeto_status_StatusId",
                table: "OrcamentoPorProjeto",
                column: "StatusId",
                principalTable: "status",
                principalColumn: "Id");
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

            migrationBuilder.DropIndex(
                name: "IX_OrcamentoPorProjeto_StatusId",
                table: "OrcamentoPorProjeto");

            migrationBuilder.DropIndex(
                name: "IX_OrcamentoHora_StatusId",
                table: "OrcamentoHora");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "OrcamentoPorProjeto");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "OrcamentoHora");
        }
    }
}
