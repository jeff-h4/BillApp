using Microsoft.EntityFrameworkCore.Migrations;

namespace BillApp.Migrations
{
    public partial class AddPatientFeeItemRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "FeeItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeeItem_PatientId",
                table: "FeeItem",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeeItem_Patient_PatientId",
                table: "FeeItem",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeeItem_Patient_PatientId",
                table: "FeeItem");

            migrationBuilder.DropIndex(
                name: "IX_FeeItem_PatientId",
                table: "FeeItem");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "FeeItem");
        }
    }
}
