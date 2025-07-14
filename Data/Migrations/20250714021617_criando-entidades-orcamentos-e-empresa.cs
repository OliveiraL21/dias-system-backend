using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class criandoentidadesorcamentoseempresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RazaoSocial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrcamentoHora",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoHora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoHora_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoHora_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrcamentoPorProjeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoPorProjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoPorProjeto_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoPorProjeto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantidadeHora = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrcamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servico_OrcamentoHora_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "OrcamentoHora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_OrcamentoPorProjeto_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "OrcamentoPorProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("49d21c0e-117b-41bc-b69d-7c21ff59a0f7"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", null, "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });


            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoHora_ClienteId",
                table: "OrcamentoHora",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoHora_EmpresaId",
                table: "OrcamentoHora",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoHora_Numero",
                table: "OrcamentoHora",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoPorProjeto_ClienteId",
                table: "OrcamentoPorProjeto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoPorProjeto_EmpresaId",
                table: "OrcamentoPorProjeto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoPorProjeto_Numero",
                table: "OrcamentoPorProjeto",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrcamentoId",
                table: "Produto",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_OrcamentoId",
                table: "Servico",
                column: "OrcamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "OrcamentoPorProjeto");

            migrationBuilder.DropTable(
                name: "OrcamentoHora");

            migrationBuilder.DropTable(
                name: "Empresa");

        }
    }
}
