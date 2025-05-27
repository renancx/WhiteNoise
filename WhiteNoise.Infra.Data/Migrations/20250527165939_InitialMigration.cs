using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoClinico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoClinico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leito",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    AgendamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissional_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Internacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataAlta = table.Column<DateTime>(nullable: true),
                    Motivo = table.Column<string>(type: "varchar(90)", nullable: true),
                    TipoSaida = table.Column<int>(nullable: true),
                    LeitoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internacao_Leito_LeitoId",
                        column: x => x.LeitoId,
                        principalTable: "Leito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alergia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(90)", nullable: true),
                    ProntuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergia_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: true),
                    LeitoId = table.Column<Guid>(nullable: true),
                    ProfissionalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Leito_LeitoId",
                        column: x => x.LeitoId,
                        principalTable: "Leito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departamento_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EstadoClinicoId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInternacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    TipoPaciente = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(type: "varchar(150)", nullable: true),
                    ProntuarioId = table.Column<Guid>(nullable: true),
                    InternacaoId = table.Column<Guid>(nullable: true),
                    AgendamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                        column: x => x.EstadoClinicoId,
                        principalTable: "EstadoClinico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Internacao_InternacaoId",
                        column: x => x.InternacaoId,
                        principalTable: "Internacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_ProntuarioId",
                table: "Alergia",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_LeitoId",
                table: "Departamento",
                column: "LeitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_ProfissionalId",
                table: "Departamento",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Internacao_LeitoId",
                table: "Internacao",
                column: "LeitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_AgendamentoId",
                table: "Paciente",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadoClinicoId",
                table: "Paciente",
                column: "EstadoClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_InternacaoId",
                table: "Paciente",
                column: "InternacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_ProntuarioId",
                table: "Paciente",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_AgendamentoId",
                table: "Profissional",
                column: "AgendamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropTable(
                name: "EstadoClinico");

            migrationBuilder.DropTable(
                name: "Internacao");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Leito");
        }
    }
}
