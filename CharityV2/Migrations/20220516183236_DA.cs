using Microsoft.EntityFrameworkCore.Migrations;

namespace CharityV2.Migrations
{
    public partial class DA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitiys_AspNetUsers_EmployeeId",
                table: "Activitiys");

            migrationBuilder.DropIndex(
                name: "IX_Activitiys_EmployeeId",
                table: "Activitiys");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Activitiys");

            migrationBuilder.CreateTable(
                name: "ActiveActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivitiyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveActivities_Activitiys_ActivitiyId",
                        column: x => x.ActivitiyId,
                        principalTable: "Activitiys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveActivities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveActivities_ActivitiyId",
                table: "ActiveActivities",
                column: "ActivitiyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveActivities_UserId",
                table: "ActiveActivities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveActivities");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Activitiys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activitiys_EmployeeId",
                table: "Activitiys",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitiys_AspNetUsers_EmployeeId",
                table: "Activitiys",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
