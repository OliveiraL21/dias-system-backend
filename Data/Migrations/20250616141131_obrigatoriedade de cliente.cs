using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class obrigatoriedadedecliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("03576817-d9b7-44e1-8412-ac78c681e5ec"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("0644a8cd-d5fe-48c4-bfd3-bf0c5649e61a"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("695bfff8-21ee-4c47-8d02-1daae105f4f7"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("6f0b8395-12f2-463f-83b5-30511237cc9c"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("abef4a27-b645-4fbc-8d2c-278ff3086d85"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: new Guid("f3460170-7499-49ab-a34d-1e4945153a4e"));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Telefone",
                keyValue: null,
                column: "Telefone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
                    { new Guid("136d4660-1914-406c-99d7-4d2f4a184c59"), null, "Em pausa", null },
                    { new Guid("533550ff-c708-4d59-ac88-3075ef438652"), null, "Excluído", null },
                    { new Guid("6cedd3ef-2f4f-44b7-8970-56377cd9de87"), null, "Bloqueado", null },
                    { new Guid("8b81d691-1449-4e53-a189-82a8509d9b0a"), null, "Ativo", null },
                    { new Guid("cc2b56a4-31fd-4ba7-9854-12b440fbfa36"), null, "Finalizado", null },
                    { new Guid("db57919f-e9b6-4eb8-b250-44293bf3df66"), null, "Inatívo", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
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
                    { new Guid("03576817-d9b7-44e1-8412-ac78c681e5ec"), null, "Bloqueado", null },
                    { new Guid("0644a8cd-d5fe-48c4-bfd3-bf0c5649e61a"), null, "Em pausa", null },
                    { new Guid("695bfff8-21ee-4c47-8d02-1daae105f4f7"), null, "Ativo", null },
                    { new Guid("6f0b8395-12f2-463f-83b5-30511237cc9c"), null, "Excluído", null },
                    { new Guid("abef4a27-b645-4fbc-8d2c-278ff3086d85"), null, "Inatívo", null },
                    { new Guid("f3460170-7499-49ab-a34d-1e4945153a4e"), null, "Finalizado", null }
                });
        }
    }
}
