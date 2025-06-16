using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionandocpfemcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("02977c04-a679-45d4-a131-1f43ed81a81f"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("5a71341a-0208-4bb7-8ef3-3fcb64672fed"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("5c5e91b4-304c-467a-bcd0-bdb7e6252244"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("6cf10bf1-430a-4ecd-a4b9-0553feb52d29"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("afbded44-566e-4290-ac32-2713a7d0fb53"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("f96f41f6-e9a1-43c9-9b5f-2247d33bc867"));

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1a1be59a-9122-42db-b42c-1c4ca1a88ba7"), null, "Finalizado", null },
                    { new Guid("1c52c1c8-a2e5-49b1-8ef1-59fe73ffaef9"), null, "Excluído", null },
                    { new Guid("802b722b-6da6-4743-9581-5b09fba2f9a1"), null, "Bloqueado", null },
                    { new Guid("8428188a-a5b0-4939-bb23-918650a67175"), null, "Em pausa", null },
                    { new Guid("b81ddf36-7d40-46f4-a5a1-10e8f7f0fc5a"), null, "Ativo", null },
                    { new Guid("cdacb5b0-3444-49ec-8f0e-b4ca583805db"), null, "Inatívo", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1a1be59a-9122-42db-b42c-1c4ca1a88ba7"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1c52c1c8-a2e5-49b1-8ef1-59fe73ffaef9"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("802b722b-6da6-4743-9581-5b09fba2f9a1"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("8428188a-a5b0-4939-bb23-918650a67175"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("b81ddf36-7d40-46f4-a5a1-10e8f7f0fc5a"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("cdacb5b0-3444-49ec-8f0e-b4ca583805db"));

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Cnpj",
                keyValue: null,
                column: "Cnpj",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("02977c04-a679-45d4-a131-1f43ed81a81f"), null, "Em pausa", null },
                    { new Guid("5a71341a-0208-4bb7-8ef3-3fcb64672fed"), null, "Inatívo", null },
                    { new Guid("5c5e91b4-304c-467a-bcd0-bdb7e6252244"), null, "Excluído", null },
                    { new Guid("6cf10bf1-430a-4ecd-a4b9-0553feb52d29"), null, "Finalizado", null },
                    { new Guid("afbded44-566e-4290-ac32-2713a7d0fb53"), null, "Bloqueado", null },
                    { new Guid("f96f41f6-e9a1-43c9-9b5f-2247d33bc867"), null, "Ativo", null }
                });
        }
    }
}
