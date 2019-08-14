using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerAdmin.Migrations
{
    public partial class Assignments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Assignment_OpportunityID",
                table: "Assignment",
                column: "OpportunityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Opportunity_OpportunityID",
                table: "Assignment",
                column: "OpportunityID",
                principalTable: "Opportunity",
                principalColumn: "OpportunityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Opportunity_OpportunityID",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_OpportunityID",
                table: "Assignment");
        }
    }
}
