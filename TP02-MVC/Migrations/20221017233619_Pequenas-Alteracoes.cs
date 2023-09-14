using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP02_MVC.Migrations
{
    public partial class PequenasAlteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_bls_bl_id",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_bl_id1",
                table: "Containers");
            migrationBuilder.CreateIndex(
                name: "IX_Containers_bl_id",
                table: "Containers",
                column: "bl_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_bls_bl_id",
                table: "Containers",
                column: "bl_id",
                principalTable: "bls",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_bls_bl_id",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_bl_id",
                table: "Containers");

            migrationBuilder.AddColumn<int>(
                name: "bl_id1",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_bl_id1",
                table: "Containers",
                column: "bl_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_bls_bl_id1",
                table: "Containers",
                column: "bl_id1",
                principalTable: "bls",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
