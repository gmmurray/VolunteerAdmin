﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerAdmin.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Available Time");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
