using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaProdutos_Categorias_CategoriaId",
                table: "VendaProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaProdutos_Vendas_VendaId",
                table: "VendaProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_VendaProdutos_CategoriaId",
                table: "VendaProdutos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "VendaProdutos");

            migrationBuilder.RenameColumn(
                name: "VendaId",
                table: "VendaProdutos",
                newName: "vendasId");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "VendaProdutos",
                newName: "idVenda");

            migrationBuilder.RenameIndex(
                name: "IX_VendaProdutos_VendaId",
                table: "VendaProdutos",
                newName: "IX_VendaProdutos_vendasId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProdutos_Vendas_vendasId",
                table: "VendaProdutos",
                column: "vendasId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaProdutos_Vendas_vendasId",
                table: "VendaProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "vendasId",
                table: "VendaProdutos",
                newName: "VendaId");

            migrationBuilder.RenameColumn(
                name: "idVenda",
                table: "VendaProdutos",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_VendaProdutos_vendasId",
                table: "VendaProdutos",
                newName: "IX_VendaProdutos_VendaId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "VendaProdutos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_CategoriaId",
                table: "VendaProdutos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProdutos_Categorias_CategoriaId",
                table: "VendaProdutos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProdutos_Vendas_VendaId",
                table: "VendaProdutos",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
