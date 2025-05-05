using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class AddConfiguratorsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                table: "Paciente");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Motivo",
                table: "Paciente",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Paciente",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Paciente",
                type: "varchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoClinico",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                table: "Paciente",
                column: "EstadoClinicoId",
                principalTable: "EstadoClinico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                table: "Paciente");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.AlterColumn<string>(
                name: "Motivo",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoClinico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_EstadoClinico_EstadoClinicoId",
                table: "Paciente",
                column: "EstadoClinicoId",
                principalTable: "EstadoClinico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
