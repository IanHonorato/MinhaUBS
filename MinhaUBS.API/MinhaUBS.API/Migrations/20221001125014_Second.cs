using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaUBS.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Unidade_ID_Unidade1",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Unidade_UnidadeID_Unidade",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacina_Unidade_UnidadeID_Unidade",
                table: "Vacina");

            migrationBuilder.DropIndex(
                name: "IX_Vacina_UnidadeID_Unidade",
                table: "Vacina");

            migrationBuilder.DropIndex(
                name: "IX_Servico_UnidadeID_Unidade",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "UnidadeID_Unidade",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "UnidadeID_Unidade",
                table: "Servico");

            migrationBuilder.RenameColumn(
                name: "ID_Unidade1",
                table: "Funcionario",
                newName: "UnidadeID_Unidade");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionario_ID_Unidade1",
                table: "Funcionario",
                newName: "IX_Funcionario_UnidadeID_Unidade");

            migrationBuilder.CreateTable(
                name: "ServicoUnidade",
                columns: table => new
                {
                    ServicosID_Servico = table.Column<int>(type: "integer", nullable: false),
                    UnidadesID_Unidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoUnidade", x => new { x.ServicosID_Servico, x.UnidadesID_Unidade });
                    table.ForeignKey(
                        name: "FK_ServicoUnidade_Servico_ServicosID_Servico",
                        column: x => x.ServicosID_Servico,
                        principalTable: "Servico",
                        principalColumn: "ID_Servico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoUnidade_Unidade_UnidadesID_Unidade",
                        column: x => x.UnidadesID_Unidade,
                        principalTable: "Unidade",
                        principalColumn: "ID_Unidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeVacina",
                columns: table => new
                {
                    UnidadesID_Unidade = table.Column<int>(type: "integer", nullable: false),
                    VacinasID_Vacina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeVacina", x => new { x.UnidadesID_Unidade, x.VacinasID_Vacina });
                    table.ForeignKey(
                        name: "FK_UnidadeVacina_Unidade_UnidadesID_Unidade",
                        column: x => x.UnidadesID_Unidade,
                        principalTable: "Unidade",
                        principalColumn: "ID_Unidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadeVacina_Vacina_VacinasID_Vacina",
                        column: x => x.VacinasID_Vacina,
                        principalTable: "Vacina",
                        principalColumn: "ID_Vacina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicoUnidade_UnidadesID_Unidade",
                table: "ServicoUnidade",
                column: "UnidadesID_Unidade");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeVacina_VacinasID_Vacina",
                table: "UnidadeVacina",
                column: "VacinasID_Vacina");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Unidade_UnidadeID_Unidade",
                table: "Funcionario",
                column: "UnidadeID_Unidade",
                principalTable: "Unidade",
                principalColumn: "ID_Unidade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Unidade_UnidadeID_Unidade",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "ServicoUnidade");

            migrationBuilder.DropTable(
                name: "UnidadeVacina");

            migrationBuilder.RenameColumn(
                name: "UnidadeID_Unidade",
                table: "Funcionario",
                newName: "ID_Unidade1");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionario_UnidadeID_Unidade",
                table: "Funcionario",
                newName: "IX_Funcionario_ID_Unidade1");

            migrationBuilder.AddColumn<int>(
                name: "UnidadeID_Unidade",
                table: "Vacina",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeID_Unidade",
                table: "Servico",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_UnidadeID_Unidade",
                table: "Vacina",
                column: "UnidadeID_Unidade");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_UnidadeID_Unidade",
                table: "Servico",
                column: "UnidadeID_Unidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Unidade_ID_Unidade1",
                table: "Funcionario",
                column: "ID_Unidade1",
                principalTable: "Unidade",
                principalColumn: "ID_Unidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Unidade_UnidadeID_Unidade",
                table: "Servico",
                column: "UnidadeID_Unidade",
                principalTable: "Unidade",
                principalColumn: "ID_Unidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacina_Unidade_UnidadeID_Unidade",
                table: "Vacina",
                column: "UnidadeID_Unidade",
                principalTable: "Unidade",
                principalColumn: "ID_Unidade",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
