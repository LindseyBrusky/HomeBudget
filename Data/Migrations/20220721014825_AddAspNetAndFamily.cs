using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudget.Data.Migrations
{
    public partial class AddAspNetAndFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Admin = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyUsers",
                columns: table => new
                {
                    FamilyUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyUsers", x => x.FamilyUserId);
                    table.ForeignKey(
                        name: "FK_FamilyUsers_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyUsers_FamilyId",
                table: "FamilyUsers",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyUsers");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
