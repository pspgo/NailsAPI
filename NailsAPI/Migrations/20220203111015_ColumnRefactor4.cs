using Microsoft.EntityFrameworkCore.Migrations;

namespace NailsAPI.Migrations
{
    public partial class ColumnRefactor4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Appointments_AppointmentId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_AppointmentId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Procedures");

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments");

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

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_AppointmentId",
                table: "Procedures",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Appointments_AppointmentId",
                table: "Procedures",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
