using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RegistroAuditableUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailUsuarioRealizoAcccion",
                table: "RegistroSAuditables");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRealizoAcccionId",
                table: "RegistroSAuditables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroSAuditables_UsuarioRealizoAcccionId",
                table: "RegistroSAuditables",
                column: "UsuarioRealizoAcccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroSAuditables_Usuarios_UsuarioRealizoAcccionId",
                table: "RegistroSAuditables",
                column: "UsuarioRealizoAcccionId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroSAuditables_Usuarios_UsuarioRealizoAcccionId",
                table: "RegistroSAuditables");

            migrationBuilder.DropIndex(
                name: "IX_RegistroSAuditables_UsuarioRealizoAcccionId",
                table: "RegistroSAuditables");

            migrationBuilder.DropColumn(
                name: "UsuarioRealizoAcccionId",
                table: "RegistroSAuditables");

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuarioRealizoAcccion",
                table: "RegistroSAuditables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
