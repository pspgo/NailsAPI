using Microsoft.EntityFrameworkCore.Migrations;

namespace NailsAPI.Migrations
{
    public partial class ColumnRefactor3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Procedures",
                newName: "ProcedurePrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Procedures",
                newName: "ProcedureName");

            migrationBuilder.RenameColumn(
                name: "EstimatedTime",
                table: "Procedures",
                newName: "ProcedureEstimatedTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Procedures",
                newName: "ProcedureDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcedurePrice",
                table: "Procedures",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ProcedureName",
                table: "Procedures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProcedureEstimatedTime",
                table: "Procedures",
                newName: "EstimatedTime");

            migrationBuilder.RenameColumn(
                name: "ProcedureDescription",
                table: "Procedures",
                newName: "Description");
        }
    }
}
