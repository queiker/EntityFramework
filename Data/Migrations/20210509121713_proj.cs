using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class proj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PassportInfo_PassportInfoId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassportInfo",
                table: "PassportInfo");

            migrationBuilder.RenameTable(
                name: "PassportInfo",
                newName: "PassportInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassportInfos",
                table: "PassportInfos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PassportInfos_PassportInfoId",
                table: "Employees",
                column: "PassportInfoId",
                principalTable: "PassportInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PassportInfos_PassportInfoId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassportInfos",
                table: "PassportInfos");

            migrationBuilder.RenameTable(
                name: "PassportInfos",
                newName: "PassportInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassportInfo",
                table: "PassportInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PassportInfo_PassportInfoId",
                table: "Employees",
                column: "PassportInfoId",
                principalTable: "PassportInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
