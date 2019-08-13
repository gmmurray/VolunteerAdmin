﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolunteerAdmin.Data;

namespace VolunteerAdmin.Migrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20190813200602_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolunteerAdmin.Models.AvailableTime", b =>
                {
                    b.Property<int>("AvailableTimeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Time");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("AvailableTimeID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Available Time");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.Center", b =>
                {
                    b.Property<int>("CenterID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CenterName");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("CenterID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.License", b =>
                {
                    b.Property<int>("LicenseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicenseName");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("LicenseID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("License");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("SkillID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.Volunteer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool?>("Approved");

                    b.Property<string>("CellPhone");

                    b.Property<bool>("DLCopyOnFile");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<string>("EmergencyAddress");

                    b.Property<string>("EmergencyEmail");

                    b.Property<string>("EmergencyHomePhone");

                    b.Property<string>("EmergencyName");

                    b.Property<string>("EmergencyWorkPhone");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<bool>("SSCopyOnFile");

                    b.Property<string>("Username");

                    b.Property<string>("WorkPhone");

                    b.HasKey("ID");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.AvailableTime", b =>
                {
                    b.HasOne("VolunteerAdmin.Models.Volunteer")
                        .WithMany("AvailableTimes")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.Center", b =>
                {
                    b.HasOne("VolunteerAdmin.Models.Volunteer")
                        .WithMany("Centers")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.License", b =>
                {
                    b.HasOne("VolunteerAdmin.Models.Volunteer")
                        .WithMany("Licenses")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("VolunteerAdmin.Models.Skill", b =>
                {
                    b.HasOne("VolunteerAdmin.Models.Volunteer")
                        .WithMany("Skills")
                        .HasForeignKey("VolunteerID");
                });
#pragma warning restore 612, 618
        }
    }
}
