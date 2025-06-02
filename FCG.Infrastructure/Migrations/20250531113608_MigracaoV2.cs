using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROMOCAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_JOGO = table.Column<int>(type: "INT", nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    DATA_INICIO = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DATA_FIM = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROMOCAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROMOCAO_JOGO_ID_JOGO",
                        column: x => x.ID_JOGO,
                        principalTable: "JOGO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROMOCAO_ID_JOGO",
                table: "PROMOCAO",
                column: "ID_JOGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROMOCAO");
        }
    }
}
