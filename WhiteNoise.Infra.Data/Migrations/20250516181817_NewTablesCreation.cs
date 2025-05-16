using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class NewTablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EstadoClinicoId",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AgendamentoId",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternacaoId",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProntuarioId",
                table: "Paciente",
                nullable: true);

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
                name: "Internacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataAlta = table.Column<DateTime>(nullable: true),
                    Motivo = table.Column<string>(type: "varchar(90)", nullable: true),
                    TipoSaida = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internacao", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_AgendamentoId",
                table: "Paciente",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_InternacaoId",
                table: "Paciente",
                column: "InternacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_ProntuarioId",
                table: "Paciente",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_ProntuarioId",
                table: "Alergia",
                column: "ProntuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Agendamento_AgendamentoId",
                table: "Paciente",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Internacao_InternacaoId",
                table: "Paciente",
                column: "InternacaoId",
                principalTable: "Internacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Prontuario_ProntuarioId",
                table: "Paciente",
                column: "ProntuarioId",
                principalTable: "Prontuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Agendamento_AgendamentoId",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Internacao_InternacaoId",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Prontuario_ProntuarioId",
                table: "Paciente");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Internacao");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_AgendamentoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_InternacaoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_ProntuarioId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "InternacaoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Paciente");

            migrationBuilder.AlterColumn<Guid>(
                name: "EstadoClinicoId",
                table: "Paciente",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
