using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoClinico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoClinico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EstadoClinicoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInternacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    TipoPaciente = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                        column: x => x.EstadoClinicoId,
                        principalTable: "EstadoClinico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadoClinicoId",
                table: "Paciente",
                column: "EstadoClinicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "EstadoClinico");
        }
    }
}
