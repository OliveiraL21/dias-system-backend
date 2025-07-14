using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoempresaseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("37e46d1e-0189-4a35-834d-f8dce4446b94"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", new DateTimeOffset(new DateTime(2025, 7, 13, 23, 23, 3, 715, DateTimeKind.Unspecified).AddTicks(9392), new TimeSpan(0, -3, 0, 0, 0)), "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Cpf", "CreateAt", "Email", "Estado", "Logradouro", "Numero", "RazaoSocial", "Telefone", "UpdateAt" },
                values: new object[] { new Guid("49d21c0e-117b-41bc-b69d-7c21ff59a0f7"), "Vila São Carlos", "(19) 99669-3155", "13847-111", "Mogi Guaçu", "476.593.238-90", null, "ljoliveira99@outlook.com", "SP", "Av São Carlos", "791", "Lucas José Dias de Oliveira", "(19) 3861-7897", null });

           
        }
    }
}
