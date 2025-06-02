using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JOGO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CATEGORIA = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOGO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SENHA = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    ADMIN = table.Column<int>(type: "INT", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BIBLIOTECA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "INT", nullable: false),
                    ID_JOGO = table.Column<int>(type: "INT", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIBLIOTECA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIBLIOTECA_JOGO_ID_JOGO",
                        column: x => x.ID_JOGO,
                        principalTable: "JOGO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BIBLIOTECA_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIBLIOTECA_ID_JOGO",
                table: "BIBLIOTECA",
                column: "ID_JOGO");

            migrationBuilder.CreateIndex(
                name: "IX_BIBLIOTECA_ID_USUARIO",
                table: "BIBLIOTECA",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIBLIOTECA");

            migrationBuilder.DropTable(
                name: "JOGO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
