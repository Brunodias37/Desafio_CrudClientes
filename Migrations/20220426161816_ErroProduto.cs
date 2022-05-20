using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudClientes.Migrations
{
    public partial class ErroProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDeFrete",
                table: "NotaFiscal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItensNotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidada = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotaFiscalId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensNotaFiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensNotaFiscal_NotaFiscal_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensNotaFiscal_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensNotaFiscal_NotaFiscalId",
                table: "ItensNotaFiscal",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensNotaFiscal_ProdutoId",
                table: "ItensNotaFiscal",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensNotaFiscal");

            migrationBuilder.DropColumn(
                name: "TipoDeFrete",
                table: "NotaFiscal");
        }
    }
}
