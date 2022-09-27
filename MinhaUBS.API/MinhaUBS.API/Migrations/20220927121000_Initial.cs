using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MinhaUBS.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    ID_Unidade = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Localizacao = table.Column<string>(type: "text", nullable: true),
                    Ativa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.ID_Unidade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    ID_Funcionario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Unidade1 = table.Column<int>(type: "integer", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Especialidade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.ID_Funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Unidade_ID_Unidade1",
                        column: x => x.ID_Unidade1,
                        principalTable: "Unidade",
                        principalColumn: "ID_Unidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    ID_Servico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    UnidadeID_Unidade = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.ID_Servico);
                    table.ForeignKey(
                        name: "FK_Servico_Unidade_UnidadeID_Unidade",
                        column: x => x.UnidadeID_Unidade,
                        principalTable: "Unidade",
                        principalColumn: "ID_Unidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    ID_Vacina = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    UnidadeID_Unidade = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.ID_Vacina);
                    table.ForeignKey(
                        name: "FK_Vacina_Unidade_UnidadeID_Unidade",
                        column: x => x.UnidadeID_Unidade,
                        principalTable: "Unidade",
                        principalColumn: "ID_Unidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_ID_Unidade1",
                table: "Funcionario",
                column: "ID_Unidade1");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_UnidadeID_Unidade",
                table: "Servico",
                column: "UnidadeID_Unidade");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_UnidadeID_Unidade",
                table: "Vacina",
                column: "UnidadeID_Unidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
