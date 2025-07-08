using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustandocamposdeprojetoparadouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("674dc864-3931-4033-b6f3-15481f5c1ca6"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("70fd5595-4bcc-47c4-a50a-b62e6fb68a4a"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("a7e623ee-627d-4d05-9639-2f06c1c68cb2"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("d14b9ee3-b070-4279-a67c-c3a80ec869a8"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("eb9498ec-8c40-4fd6-ad18-1b12ae82e260"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("f5c90079-a73f-42dd-942c-443d9de361bd"));

            migrationBuilder.AlterColumn<double>(
                name: "TotalHoras",
                table: "Projetos",
                type: "double",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("053e5bde-9923-4f6b-9761-c4d47675c8e6"), null, "Inatívo", null },
                    { new Guid("1ba640f9-a3ce-4770-b326-7c895f2cfc6a"), null, "Excluído", null },
                    { new Guid("298d8321-76a1-42d3-99f2-7cccbf75b031"), null, "Finalizado", null },
                    { new Guid("4dce8810-7dd6-4e47-a7fc-f5895f8caaff"), null, "Bloqueado", null },
                    { new Guid("88c490c0-e9fa-4b01-89d4-00e1f3fa40bc"), null, "Em pausa", null },
                    { new Guid("a27873b5-4f2e-4be8-baf9-8522b96de026"), null, "Em andamento", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("053e5bde-9923-4f6b-9761-c4d47675c8e6"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("1ba640f9-a3ce-4770-b326-7c895f2cfc6a"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("298d8321-76a1-42d3-99f2-7cccbf75b031"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("4dce8810-7dd6-4e47-a7fc-f5895f8caaff"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("88c490c0-e9fa-4b01-89d4-00e1f3fa40bc"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("a27873b5-4f2e-4be8-baf9-8522b96de026"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TotalHoras",
                table: "Projetos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("674dc864-3931-4033-b6f3-15481f5c1ca6"), null, "Finalizado", null },
                    { new Guid("70fd5595-4bcc-47c4-a50a-b62e6fb68a4a"), null, "Bloqueado", null },
                    { new Guid("a7e623ee-627d-4d05-9639-2f06c1c68cb2"), null, "Inatívo", null },
                    { new Guid("d14b9ee3-b070-4279-a67c-c3a80ec869a8"), null, "Em andamento", null },
                    { new Guid("eb9498ec-8c40-4fd6-ad18-1b12ae82e260"), null, "Em pausa", null },
                    { new Guid("f5c90079-a73f-42dd-942c-443d9de361bd"), null, "Excluído", null }
                });
        }
    }
}
