using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudClientes.Migrations
{
    public partial class ItensNotaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidada",
                table: "ItensNotaFiscal",
                newName: "Quantidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "ItensNotaFiscal",
                newName: "Quantidada");
        }
    }
}
