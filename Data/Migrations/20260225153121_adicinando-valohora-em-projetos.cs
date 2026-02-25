using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adicinandovalohoraemprojetos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: new Guid("d05d99d2-3366-4043-ac93-087184b795a6"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("0ec9461c-ba2d-498a-aaf8-b704fcaa7754"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("350727fc-e28e-46c8-95a6-7fe7388938db"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("4e83247f-4add-484e-8fb1-9d916a696757"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("6fe4206c-06ea-4090-b76e-ac2ed3b013a5"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("c22ad5ee-49ed-4d1e-bc68-dba0a94a1e96"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("d0e25a70-8f58-47d9-b45f-ac757c147dab"));

            migrationBuilder.AddColumn<double>(
                name: "ValorHora",
                table: "Projetos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorHora",
                table: "Projetos");

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("d05d99d2-3366-4043-ac93-087184b795a6"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", new DateTimeOffset(new DateTime(2025, 8, 4, 11, 49, 50, 799, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, -3, 0, 0, 0)), "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0ec9461c-ba2d-498a-aaf8-b704fcaa7754"), null, "Bloqueado", null },
                    { new Guid("350727fc-e28e-46c8-95a6-7fe7388938db"), null, "Em pausa", null },
                    { new Guid("4e83247f-4add-484e-8fb1-9d916a696757"), null, "Finalizado", null },
                    { new Guid("6fe4206c-06ea-4090-b76e-ac2ed3b013a5"), null, "Inativo", null },
                    { new Guid("c22ad5ee-49ed-4d1e-bc68-dba0a94a1e96"), null, "Em andamento", null },
                    { new Guid("d0e25a70-8f58-47d9-b45f-ac757c147dab"), null, "Excluído", null }
                });
        }
    }
}
