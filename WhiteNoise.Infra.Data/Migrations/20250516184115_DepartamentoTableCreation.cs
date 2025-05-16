using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class DepartamentoTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeitoId",
                table: "Internacao",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Internacao_LeitoId",
                table: "Internacao",
                column: "LeitoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Internacao_Leito_LeitoId",
                table: "Internacao",
                column: "LeitoId",
                principalTable: "Leito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internacao_Leito_LeitoId",
                table: "Internacao");

            migrationBuilder.DropTable(
                name: "Leito");

            migrationBuilder.DropIndex(
                name: "IX_Internacao_LeitoId",
                table: "Internacao");

            migrationBuilder.DropColumn(
                name: "LeitoId",
                table: "Internacao");
        }
    }
}
