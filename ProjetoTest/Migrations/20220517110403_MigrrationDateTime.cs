using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTest.Migrations
{
    public partial class MigrrationDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Material_SupplierId",
                table: "Material",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Supplier_SupplierId",
                table: "Material",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Supplier_SupplierId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_SupplierId",
                table: "Material");
        }
    }
}
