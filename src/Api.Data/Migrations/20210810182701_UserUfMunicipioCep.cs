using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UserUfMunicipioCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    CodIBGE = table.Column<int>(nullable: false),
                    UfId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 60, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    MunicipioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cep_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("22a0bd4f-c522-4c60-97f0-16ca0e0d6acf"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8033), "Acre", "AC", null },
                    { new Guid("b19a38f4-58e5-4f8a-8c6e-b03d2b44b12d"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8184), "Tocantins", "TO", null },
                    { new Guid("c7992b37-2dae-4684-a2c3-300e86755b70"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8180), "Sergipe", "SE", null },
                    { new Guid("0a66e2bb-a0e0-497f-80a7-dd4181477ae6"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8177), "São Paulo", "SP", null },
                    { new Guid("85266add-5a70-4024-a059-180ac6356051"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8173), "Santa Catarina", "SC", null },
                    { new Guid("101dce22-a876-406d-bfb7-8fdb2c708ca8"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8170), "Roraima", "RR", null },
                    { new Guid("3540e439-94c0-44c1-aeb0-aef4f813f158"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8167), "Rondônia", "RO", null },
                    { new Guid("7236af06-c7ae-4890-92f2-ea061cd24a0a"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8163), "Rio Grande do Sul", "RS", null },
                    { new Guid("1254ea3a-35f2-4089-aedb-7aeaafffd307"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8160), "Rio Grande do Norte", "RN", null },
                    { new Guid("b70610c8-1e91-4d86-b46d-b03b244db4c4"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8156), "Rio de Janeiro", "RJ", null },
                    { new Guid("2c777073-9e1c-4a89-988c-e1c970a66571"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8153), "Piauí", "PI", null },
                    { new Guid("037527c0-19f4-4b15-9ba1-03cc88af3978"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8150), "Pernambuco", "PE", null },
                    { new Guid("ec42a205-241e-459b-a3f1-da614e5a55cc"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8145), "Paraná", "PR", null },
                    { new Guid("4a2f7aa7-bf01-42d9-b2e4-142483eaf3cc"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8142), "Paraíba", "PB", null },
                    { new Guid("c3f8c57e-1132-4b48-a87f-d77782cbea02"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8138), "Pará", "PA", null },
                    { new Guid("8ff95a8b-60da-48ee-aee9-405e10de9488"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8135), "Minas Gerais", "MG", null },
                    { new Guid("909515cb-a35c-4477-b02a-5a0e16971fad"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8131), "Mato Grosso do Sul", "MS", null },
                    { new Guid("8b5a8424-700b-472c-a498-aed122a0924e"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8127), "Mato Grosso", "MT", null },
                    { new Guid("8fbd96b4-d62a-41b4-9537-99de60723c92"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8124), "Maranhão", "MA", null },
                    { new Guid("9ac88f48-ca7b-4469-ae10-d1e8df5cf20b"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8120), "Goiás", "GO", null },
                    { new Guid("2c976982-9c2d-4479-b920-c5b2a07780f6"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8116), "Espírito Santo", "ES", null },
                    { new Guid("8b0432f9-e794-4407-b8f3-d084eaa079f4"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8113), "Ceará", "CE", null },
                    { new Guid("7fe87dfe-6362-4676-bfd0-95d072918585"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8109), "Bahia", "BA", null },
                    { new Guid("863f2e0d-2107-41c3-aa3f-57c647e8f400"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8103), "Amazonas", "AM", null },
                    { new Guid("7cb1b6c6-5e64-43f0-86fc-0a3b3e08432d"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8099), "Amapá", "AP", null },
                    { new Guid("2e21c8eb-cbaa-4235-98e8-ac3540276dc0"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8093), "Alagoas", "AL", null },
                    { new Guid("b1147acc-bab8-4263-91ec-6f85ebc907ff"), new DateTime(2021, 8, 10, 18, 27, 1, 74, DateTimeKind.Utc).AddTicks(8188), "Distrito Federal", "DF", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("8c513481-7bfd-4b71-9fc2-b96afc8ac9a7"), new DateTime(2021, 8, 10, 15, 27, 1, 70, DateTimeKind.Local).AddTicks(3052), "admin@mail.com.br", "Administrador", new DateTime(2021, 8, 10, 15, 27, 1, 71, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.CreateIndex(
                name: "IX_Cep_Cep",
                table: "Cep",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Cep_MunicipioId",
                table: "Cep",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_CodIBGE",
                table: "Municipio",
                column: "CodIBGE");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_UfId",
                table: "Municipio",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Sigla",
                table: "Uf",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Uf");
        }
    }
}
