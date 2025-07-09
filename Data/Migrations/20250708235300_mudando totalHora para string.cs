using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mudandototalHoraparastring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "TotalHoras",
                table: "Projetos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("4a340363-cde4-4977-9135-832f84125d2b"), null, "Em andamento", null },
                    { new Guid("53d9ee70-8e2c-47b7-b2f0-8dca2969c4bb"), null, "Excluído", null },
                    { new Guid("767dc9cb-e820-4683-b427-4cfe1b08ac9b"), null, "Em pausa", null },
                    { new Guid("b1d67e00-0de3-445a-95cd-613a9a258ca3"), null, "Bloqueado", null },
                    { new Guid("beb08c59-dafa-4fdb-8fc8-fcaed235fb45"), null, "Inatívo", null },
                    { new Guid("d5309972-71c6-40cf-9d9d-8ed605bc9f08"), null, "Finalizado", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("4a340363-cde4-4977-9135-832f84125d2b"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("53d9ee70-8e2c-47b7-b2f0-8dca2969c4bb"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("767dc9cb-e820-4683-b427-4cfe1b08ac9b"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("b1d67e00-0de3-445a-95cd-613a9a258ca3"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("beb08c59-dafa-4fdb-8fc8-fcaed235fb45"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("d5309972-71c6-40cf-9d9d-8ed605bc9f08"));

            migrationBuilder.AlterColumn<double>(
                name: "TotalHoras",
                table: "Projetos",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
