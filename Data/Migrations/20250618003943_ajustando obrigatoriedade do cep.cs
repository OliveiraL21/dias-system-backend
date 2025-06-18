using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoobrigatoriedadedocep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("095f80e6-6212-4e16-9128-f21350d71526"), null, "Bloqueado", null },
                    { new Guid("1d36b2ee-2485-42db-97b1-479730bae578"), null, "Ativo", null },
                    { new Guid("35695b61-40af-48d1-b63f-ee4246994130"), null, "Finalizado", null },
                    { new Guid("a94dc714-3aa0-433b-a5d7-babb57c26e3f"), null, "Inatívo", null },
                    { new Guid("c818cba0-e0d0-4287-8f25-15234ce65444"), null, "Excluído", null },
                    { new Guid("ef27c2d8-82ea-489a-b95c-c133d5aef8f4"), null, "Em pausa", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("095f80e6-6212-4e16-9128-f21350d71526"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1d36b2ee-2485-42db-97b1-479730bae578"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("35695b61-40af-48d1-b63f-ee4246994130"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("a94dc714-3aa0-433b-a5d7-babb57c26e3f"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("c818cba0-e0d0-4287-8f25-15234ce65444"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("ef27c2d8-82ea-489a-b95c-c133d5aef8f4"));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Cep",
                keyValue: null,
                column: "Cep",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
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
                    { new Guid("1a1be59a-9122-42db-b42c-1c4ca1a88ba7"), null, "Finalizado", null },
                    { new Guid("1c52c1c8-a2e5-49b1-8ef1-59fe73ffaef9"), null, "Excluído", null },
                    { new Guid("802b722b-6da6-4743-9581-5b09fba2f9a1"), null, "Bloqueado", null },
                    { new Guid("8428188a-a5b0-4939-bb23-918650a67175"), null, "Em pausa", null },
                    { new Guid("b81ddf36-7d40-46f4-a5a1-10e8f7f0fc5a"), null, "Ativo", null },
                    { new Guid("cdacb5b0-3444-49ec-8f0e-b4ca583805db"), null, "Inatívo", null }
                });
        }
    }
}
