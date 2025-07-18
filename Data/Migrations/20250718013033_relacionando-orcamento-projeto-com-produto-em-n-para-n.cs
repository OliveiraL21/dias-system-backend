using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class relacionandoorcamentoprojetocomprodutoemnparan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_OrcamentoPorProjeto_OrcamentoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_OrcamentoId",
                table: "Produto");


            migrationBuilder.DropColumn(
                name: "OrcamentoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "produtoOrcamentoProjeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotalVenda = table.Column<double>(type: "double", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoOrcamentoProjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtoOrcamentoProjeto_OrcamentoPorProjeto_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "OrcamentoPorProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produtoOrcamentoProjeto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_produtoOrcamentoProjeto_OrcamentoId",
                table: "produtoOrcamentoProjeto",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtoOrcamentoProjeto_ProdutoId",
                table: "produtoOrcamentoProjeto",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtoOrcamentoProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrcamentoId",
                table: "Produto",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_OrcamentoPorProjeto_OrcamentoId",
                table: "Produto",
                column: "OrcamentoId",
                principalTable: "OrcamentoPorProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
