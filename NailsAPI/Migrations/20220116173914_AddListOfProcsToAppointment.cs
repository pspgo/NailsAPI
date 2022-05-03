using Microsoft.EntityFrameworkCore.Migrations;

namespace NailsAPI.Migrations
{
    public partial class AddListOfProcsToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Appointments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
