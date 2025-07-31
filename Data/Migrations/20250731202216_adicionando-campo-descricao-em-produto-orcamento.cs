using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionandocampodescricaoemprodutoorcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: new Guid("01d747fb-49ff-49e9-8868-ae2bc48b067f"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("073a5977-0954-4c16-a740-ef5b07f9570e"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1b5bfe51-6ca1-4fb8-8279-67132385bac8"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("da70c55b-de99-4352-af4a-9d52f92cd2e2"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("e26ebaf4-8707-4311-9a89-7f908cd3f32d"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("f26b8b29-e6f2-477e-ba05-10d368d8b221"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("fa5f6b28-934f-4bfa-a662-27af0b3cc723"));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "produtoOrcamentoProjeto",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("17dcf27b-687b-45dc-ac6c-af7d8509885f"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", new DateTimeOffset(new DateTime(2025, 7, 31, 17, 22, 13, 460, DateTimeKind.Unspecified).AddTicks(4647), new TimeSpan(0, -3, 0, 0, 0)), "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0e55133f-4498-4d26-81d3-7d227c4f7e32"), null, "Inativo", null },
                    { new Guid("1dea4193-5978-475a-82f4-28d8c471f364"), null, "Finalizado", null },
                    { new Guid("3bb93508-9f63-43d9-a49e-981072020ba0"), null, "Excluído", null },
                    { new Guid("44e89bec-11c0-4025-8b68-dc1264192b85"), null, "Em andamento", null },
                    { new Guid("ac8de1e3-a862-4ee1-8e8e-0c31b064a0ea"), null, "Em pausa", null },
                    { new Guid("f7397de6-65e9-45be-b096-85373719624b"), null, "Bloqueado", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: new Guid("17dcf27b-687b-45dc-ac6c-af7d8509885f"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("0e55133f-4498-4d26-81d3-7d227c4f7e32"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1dea4193-5978-475a-82f4-28d8c471f364"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("3bb93508-9f63-43d9-a49e-981072020ba0"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("44e89bec-11c0-4025-8b68-dc1264192b85"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("ac8de1e3-a862-4ee1-8e8e-0c31b064a0ea"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("f7397de6-65e9-45be-b096-85373719624b"));

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "produtoOrcamentoProjeto");

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("01d747fb-49ff-49e9-8868-ae2bc48b067f"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", new DateTimeOffset(new DateTime(2025, 7, 25, 18, 49, 31, 858, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, -3, 0, 0, 0)), "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("073a5977-0954-4c16-a740-ef5b07f9570e"), null, "Em andamento", null },
                    { new Guid("1b5bfe51-6ca1-4fb8-8279-67132385bac8"), null, "Bloqueado", null },
                    { new Guid("da70c55b-de99-4352-af4a-9d52f92cd2e2"), null, "Inativo", null },
                    { new Guid("e26ebaf4-8707-4311-9a89-7f908cd3f32d"), null, "Finalizado", null },
                    { new Guid("f26b8b29-e6f2-477e-ba05-10d368d8b221"), null, "Em pausa", null },
                    { new Guid("fa5f6b28-934f-4bfa-a662-27af0b3cc723"), null, "Excluído", null }
                });
        }
    }
}
