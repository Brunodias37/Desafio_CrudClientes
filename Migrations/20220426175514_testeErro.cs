using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudClientes.Migrations
{
    public partial class testeErro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "NotaFiscal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "NotaFiscal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
