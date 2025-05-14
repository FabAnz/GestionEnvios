using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ClienteEnEnvio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_VendedorId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "EmailCliente",
                table: "Envios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Envios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_VendedorId",
                table: "Envios",
                column: "VendedorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_VendedorId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Envios");

            migrationBuilder.AddColumn<string>(
                name: "EmailCliente",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_VendedorId",
                table: "Envios",
                column: "VendedorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
