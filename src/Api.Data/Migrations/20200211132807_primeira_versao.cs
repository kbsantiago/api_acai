using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class primeira_versao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TempoDePreparo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamanhos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TempoDePreparo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    SaborId = table.Column<long>(nullable: false),
                    TamanhoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Tamanhos_TamanhoId",
                        column: x => x.TamanhoId,
                        principalTable: "Tamanhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    TempoDePreparo = table.Column<int>(nullable: false, defaultValue: 0),
                    ItemPedidoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_ItemPedido_ItemPedidoId",
                        column: x => x.ItemPedidoId,
                        principalTable: "ItemPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adicionais",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TempoDePreparo = table.Column<int>(nullable: false),
                    PedidoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adicionais_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedidoAdicionais",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ItemPedidoId = table.Column<long>(nullable: false),
                    AdicionalId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoAdicionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedidoAdicionais_Adicionais_AdicionalId",
                        column: x => x.AdicionalId,
                        principalTable: "Adicionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoAdicionais_ItemPedido_ItemPedidoId",
                        column: x => x.ItemPedidoId,
                        principalTable: "ItemPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adicionais_Descricao",
                table: "Adicionais",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adicionais_PedidoId",
                table: "Adicionais",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_SaborId",
                table: "ItemPedido",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_TamanhoId",
                table: "ItemPedido",
                column: "TamanhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoAdicionais_AdicionalId",
                table: "ItemPedidoAdicionais",
                column: "AdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoAdicionais_ItemPedidoId",
                table: "ItemPedidoAdicionais",
                column: "ItemPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ItemPedidoId",
                table: "Pedidos",
                column: "ItemPedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sabores_Descricao",
                table: "Sabores",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tamanhos_Descricao",
                table: "Tamanhos",
                column: "Descricao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedidoAdicionais");

            migrationBuilder.DropTable(
                name: "Adicionais");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Tamanhos");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");
        }
    }
}
