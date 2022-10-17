using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilityEye.Migrations
{
    public partial class AddFormControlsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormControls_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormControlOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormControlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormControlOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormControlOptions_FormControls_FormControlId",
                        column: x => x.FormControlId,
                        principalTable: "FormControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormControlOptions_FormControlId",
                table: "FormControlOptions",
                column: "FormControlId");

            migrationBuilder.CreateIndex(
                name: "IX_FormControls_FormId",
                table: "FormControls",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormControlOptions");

            migrationBuilder.DropTable(
                name: "FormControls");
        }
    }
}
