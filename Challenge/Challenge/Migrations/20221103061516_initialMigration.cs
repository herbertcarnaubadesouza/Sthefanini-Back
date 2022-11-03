using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCliente = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    EmailCliente = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    ItensPedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.ItensPedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId");
                    table.ForeignKey(
                        name: "FK_produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
