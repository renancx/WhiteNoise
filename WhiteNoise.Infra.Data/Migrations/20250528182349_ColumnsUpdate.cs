using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteNoise.Infra.Data.Migrations
{
    public partial class ColumnsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Leito",
                type: "varchar(90)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Leito");
        }
    }
}
