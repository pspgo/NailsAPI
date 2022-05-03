using Microsoft.EntityFrameworkCore.Migrations;

namespace NailsAPI.Migrations
{
    public partial class ColumnRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "Procedures",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Procedures",
                newName: "ProcedureId");
        }
    }
}
