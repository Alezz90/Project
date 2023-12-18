using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicSystem.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Person_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Person_Id);
                });

            migrationBuilder.CreateTable(
                name: "specialization",
                columns: table => new
                {
                    SpeciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specia_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialization", x => x.SpeciaID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appoinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_ID = table.Column<int>(type: "int", nullable: false),
                    specialization_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Persons_person_ID",
                        column: x => x.person_ID,
                        principalTable: "Persons",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_specialization_specialization_ID",
                        column: x => x.specialization_ID,
                        principalTable: "specialization",
                        principalColumn: "SpeciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_person_ID",
                table: "Appointments",
                column: "person_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_specialization_ID",
                table: "Appointments",
                column: "specialization_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "specialization");
        }
    }
}
