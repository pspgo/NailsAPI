using Microsoft.EntityFrameworkCore.Migrations;

namespace NailsAPI.Migrations
{
    public partial class AppointmentUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CreatedById",
                table: "Appointments",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_CreatedById",
                table: "Appointments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_CreatedById",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CreatedById",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Appointments");
        }
    }
}
