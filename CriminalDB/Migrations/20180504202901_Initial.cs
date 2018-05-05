using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriminalDB.Migrations
{
    public partial class Initial : Migration
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
                    CrimeID = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Criminals_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    CrimeID = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Victims_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criminals_CrimeID",
                table: "Criminals",
                column: "CrimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_CrimeID",
                table: "Victims",
                column: "CrimeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "Crimes");
        }
    }
}
