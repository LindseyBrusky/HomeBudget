using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudget.Data.Migrations
{
    public partial class UpdateAppUserAndFamilyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CurrentFamilyId",
                table: "AppUsers",
                column: "CurrentFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Families_CurrentFamilyId",
                table: "AppUsers",
                column: "CurrentFamilyId",
                principalTable: "Families",
                principalColumn: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Families_CurrentFamilyId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CurrentFamilyId",
                table: "AppUsers");
        }
    }
}
