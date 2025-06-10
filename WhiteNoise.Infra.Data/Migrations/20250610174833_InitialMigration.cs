using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(90)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
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
                name: "Prontuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QueixaPrincipal = table.Column<string>(type: "varchar(90)", maxLength: 100, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(90)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leito",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leito_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(90)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(90)", maxLength: 100, nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Cpf = table.Column<string>(type: "varchar(90)", maxLength: 11, nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EmInternacao = table.Column<bool>(nullable: true, defaultValue: false),
                    TipoSanguineo = table.Column<int>(nullable: true),
                    TipoPaciente = table.Column<int>(nullable: true),
                    EstadoClinicoId = table.Column<Guid>(nullable: true),
                    RegistroProfissional = table.Column<string>(type: "varchar(90)", maxLength: 50, nullable: true),
                    DepartamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_EstadoClinico_EstadoClinicoId",
                        column: x => x.EstadoClinicoId,
                        principalTable: "EstadoClinico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(90)", maxLength: 500, nullable: true),
                    ProfissionalId = table.Column<Guid>(nullable: true),
                    PacienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pessoa_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pessoa_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Pessoa",
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
                    Motivo = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 200, nullable: false),
                    TipoSaida = table.Column<int>(nullable: true),
                    Ativa = table.Column<bool>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: true),
                    LeitoId = table.Column<Guid>(nullable: true),
                    ProntuarioId = table.Column<Guid>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Internacao_Pessoa_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internacao_Prontuario_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EstadoClinico",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("a4a4a4a4-0000-0000-0000-000000000001"), "Estável" },
                    { new Guid("a4a4a4a4-0000-0000-0000-000000000002"), "Observação" },
                    { new Guid("a4a4a4a4-0000-0000-0000-000000000003"), "Grave" },
                    { new Guid("a4a4a4a4-0000-0000-0000-000000000004"), "Crítico" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Internacao_LeitoId",
                table: "Internacao",
                column: "LeitoId",
                unique: true,
                filter: "[LeitoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Internacao_PacienteId",
                table: "Internacao",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Internacao_ProntuarioId",
                table: "Internacao",
                column: "ProntuarioId",
                unique: true,
                filter: "[ProntuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Leito_DepartamentoId",
                table: "Leito",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EstadoClinicoId",
                table: "Pessoa",
                column: "EstadoClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Cpf",
                table: "Pessoa",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_DepartamentoId",
                table: "Pessoa",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Internacao");

            migrationBuilder.DropTable(
                name: "Leito");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "EstadoClinico");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
