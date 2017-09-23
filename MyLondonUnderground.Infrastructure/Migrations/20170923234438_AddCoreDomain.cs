using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLondonUnderground.Infrastructure.Migrations
{
    public partial class AddCoreDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TubeLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Colour = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ObjectState = table.Column<int>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TubeLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TubeLineStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    HasNationalRailConnection = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasStepFreeAccessFromStreetToPlatform = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasStepFreeAccessFromStreetToTrain = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ObjectState = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TubeLineStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TubeLineToTubeLineStationMap",
                columns: table => new
                {
                    TubeLineId = table.Column<int>(type: "INTEGER", nullable: false),
                    TubeLineStationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TubeLineToTubeLineStationMap", x => new { x.TubeLineId, x.TubeLineStationId });
                    table.ForeignKey(
                        name: "FK_TubeLineToTubeLineStationMap_TubeLines_TubeLineId",
                        column: x => x.TubeLineId,
                        principalTable: "TubeLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TubeLineToTubeLineStationMap_TubeLineStations_TubeLineStationId",
                        column: x => x.TubeLineStationId,
                        principalTable: "TubeLineStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TubeLineToTubeLineStationMap_TubeLineStationId",
                table: "TubeLineToTubeLineStationMap",
                column: "TubeLineStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TubeLineToTubeLineStationMap");

            migrationBuilder.DropTable(
                name: "TubeLines");

            migrationBuilder.DropTable(
                name: "TubeLineStations");
        }
    }
}
