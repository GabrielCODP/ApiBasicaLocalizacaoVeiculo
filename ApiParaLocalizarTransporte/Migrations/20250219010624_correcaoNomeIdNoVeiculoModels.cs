using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiParaLocalizarTransporte.Migrations
{
    /// <inheritdoc />
    public partial class correcaoNomeIdNoVeiculoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Linhas_LinhaId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "LinhdaId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Linhas_LinhaId",
                table: "Veiculos",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "LinhaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Linhas_LinhaId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Veiculos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LinhdaId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Linhas_LinhaId",
                table: "Veiculos",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "LinhaId");
        }
    }
}
