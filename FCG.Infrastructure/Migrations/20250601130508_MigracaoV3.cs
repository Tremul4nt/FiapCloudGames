using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SENHA",
                table: "USUARIO");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "USUARIO",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "USUARIO",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "USUARIO");

            migrationBuilder.AddColumn<string>(
                name: "SENHA",
                table: "USUARIO",
                type: "VARCHAR(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
