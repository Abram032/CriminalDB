using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriminalDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.CrimeID);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(maxLength: 250, nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(maxLength: 250, nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CrimeCriminal",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeCriminal", x => new { x.CrimeID, x.ID });
                    table.ForeignKey(
                        name: "FK_CrimeCriminal_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeCriminal_Criminals_ID",
                        column: x => x.ID,
                        principalTable: "Criminals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrimeVictim",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeVictim", x => new { x.CrimeID, x.ID });
                    table.ForeignKey(
                        name: "FK_CrimeVictim_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeVictim_Victims_ID",
                        column: x => x.ID,
                        principalTable: "Victims",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeCriminal_ID",
                table: "CrimeCriminal",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeVictim_ID",
                table: "CrimeVictim",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeCriminal");

            migrationBuilder.DropTable(
                name: "CrimeVictim");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Victims");
        }
    }
}
