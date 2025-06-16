using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionandonovosdadosemcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("136d4660-1914-406c-99d7-4d2f4a184c59"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("533550ff-c708-4d59-ac88-3075ef438652"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("6cedd3ef-2f4f-44b7-8970-56377cd9de87"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("8b81d691-1449-4e53-a189-82a8509d9b0a"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("cc2b56a4-31fd-4ba7-9854-12b440fbfa36"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("db57919f-e9b6-4eb8-b250-44293bf3df66"));

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Clientes");

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "CreateAt", "Descricao", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("136d4660-1914-406c-99d7-4d2f4a184c59"), null, "Em pausa", null },
                    { new Guid("533550ff-c708-4d59-ac88-3075ef438652"), null, "Excluído", null },
                    { new Guid("6cedd3ef-2f4f-44b7-8970-56377cd9de87"), null, "Bloqueado", null },
                    { new Guid("8b81d691-1449-4e53-a189-82a8509d9b0a"), null, "Ativo", null },
                    { new Guid("cc2b56a4-31fd-4ba7-9854-12b440fbfa36"), null, "Finalizado", null },
                    { new Guid("db57919f-e9b6-4eb8-b250-44293bf3df66"), null, "Inatívo", null }
                });
        }
    }
}
