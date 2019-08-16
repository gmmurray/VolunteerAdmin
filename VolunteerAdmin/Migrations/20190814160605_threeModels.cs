using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerAdmin.Migrations
{
    public partial class threeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Available Time");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.AddColumn<string>(
                name: "AvailableTimes",
                table: "Volunteer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Centers",
                table: "Volunteer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licenses",
                table: "Volunteer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Volunteer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableTimes",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "Centers",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "Licenses",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Volunteer");

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
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skill_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Skill_VolunteerID",
                table: "Skill",
                column: "VolunteerID");
        }
    }
}
