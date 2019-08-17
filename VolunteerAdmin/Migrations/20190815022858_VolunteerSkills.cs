using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerAdmin.Migrations
{
    public partial class VolunteerSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    OpportunityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CenterID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OpportunityName = table.Column<string>(nullable: true),
                    OpportunityDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.OpportunityID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    EmergencyName = table.Column<string>(nullable: true),
                    EmergencyHomePhone = table.Column<string>(nullable: true),
                    EmergencyWorkPhone = table.Column<string>(nullable: true),
                    EmergencyEmail = table.Column<string>(nullable: true),
                    EmergencyAddress = table.Column<string>(nullable: true),
                    DLCopyOnFile = table.Column<bool>(nullable: false),
                    SSCopyOnFile = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OppReqSkill",
                columns: table => new
                {
                    OppReqSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpportunityID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OppReqSkill", x => x.OppReqSkillID);
                    table.ForeignKey(
                        name: "FK_OppReqSkill_Opportunity_OpportunityID",
                        column: x => x.OpportunityID,
                        principalTable: "Opportunity",
                        principalColumn: "OpportunityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OppReqSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpportunityID = table.Column<int>(nullable: false),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignment_Opportunity_OpportunityID",
                        column: x => x.OpportunityID,
                        principalTable: "Opportunity",
                        principalColumn: "OpportunityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Available Time",
                columns: table => new
                {
                    AvailableTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false),
                    VolunteerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available Time", x => x.AvailableTimeID);
                    table.ForeignKey(
                        name: "FK_Available Time_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    CenterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CenterName = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                    table.ForeignKey(
                        name: "FK_Center_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    LicenseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LicenseName = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.LicenseID);
                    table.ForeignKey(
                        name: "FK_License_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerSkill",
                columns: table => new
                {
                    VolunteerSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillID = table.Column<int>(nullable: false),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerSkill", x => x.VolunteerSkillID);
                    table.ForeignKey(
                        name: "FK_VolunteerSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerSkill_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_OpportunityID",
                table: "Assignment",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_VolunteerID",
                table: "Assignment",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_Available Time_VolunteerID",
                table: "Available Time",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_Center_VolunteerID",
                table: "Center",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_License_VolunteerID",
                table: "License",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_OppReqSkill_OpportunityID",
                table: "OppReqSkill",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_OppReqSkill_SkillID",
                table: "OppReqSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkill_SkillID",
                table: "VolunteerSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSkill_VolunteerID",
                table: "VolunteerSkill",
                column: "VolunteerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Available Time");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "OppReqSkill");

            migrationBuilder.DropTable(
                name: "VolunteerSkill");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
