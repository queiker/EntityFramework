using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class pass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassportInfoId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PassportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PassportInfoId",
                table: "Employees",
                column: "PassportInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PassportInfo_PassportInfoId",
                table: "Employees",
                column: "PassportInfoId",
                principalTable: "PassportInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PassportInfo_PassportInfoId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "PassportInfo");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PassportInfoId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PassportInfoId",
                table: "Employees");
        }
    }
}
