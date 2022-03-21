using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationsApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormedRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormedRegistrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationAttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegValues_RegAttributes_RegistrationAttributeId",
                        column: x => x.RegistrationAttributeId,
                        principalTable: "RegAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueRegistrations",
                columns: table => new
                {
                    RegValueId = table.Column<int>(type: "int", nullable: false),
                    FormedRegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueRegistrations", x => new { x.FormedRegistrationId, x.RegValueId });
                    table.ForeignKey(
                        name: "FK_ValueRegistrations_FormedRegistrations_FormedRegistrationId",
                        column: x => x.FormedRegistrationId,
                        principalTable: "FormedRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValueRegistrations_RegValues_RegValueId",
                        column: x => x.RegValueId,
                        principalTable: "RegValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegValues_RegistrationAttributeId",
                table: "RegValues",
                column: "RegistrationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueRegistrations_RegValueId",
                table: "ValueRegistrations",
                column: "RegValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValueRegistrations");

            migrationBuilder.DropTable(
                name: "FormedRegistrations");

            migrationBuilder.DropTable(
                name: "RegValues");

            migrationBuilder.DropTable(
                name: "RegAttributes");
        }
    }
}
