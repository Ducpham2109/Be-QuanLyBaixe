﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DATN.Infastructure.Migrations
{
    public partial class _22052023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    ParkingCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParkingAddress = table.Column<string>(type: "text", nullable: true),
                    ParkingName = table.Column<string>(type: "text", nullable: true),
                    MnPrice = table.Column<int>(type: "integer", nullable: false),
                    MmPrice = table.Column<int>(type: "integer", nullable: false),
                    NnPrice = table.Column<int>(type: "integer", nullable: false),
                    NmPrice = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.ParkingCode);
                });

            migrationBuilder.CreateTable(
                name: "EntryVehicles",
                columns: table => new
                {
                    LisenseVehicle = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    VehicleyType = table.Column<string>(type: "text", nullable: true),
                    EntryTime = table.Column<string>(type: "text", nullable: true),
                    ParkingCode = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryVehicles", x => x.LisenseVehicle);
                    table.ForeignKey(
                        name: "FK_EntryVehicles_Accounts_Username",
                        column: x => x.Username,
                        principalTable: "Accounts",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryVehicles_Parkings_ParkingCode",
                        column: x => x.ParkingCode,
                        principalTable: "Parkings",
                        principalColumn: "ParkingCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managements",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    ParkingCode = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managements", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Managements_Accounts_Username",
                        column: x => x.Username,
                        principalTable: "Accounts",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Managements_Parkings_ParkingCode",
                        column: x => x.ParkingCode,
                        principalTable: "Parkings",
                        principalColumn: "ParkingCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    VehicleyType = table.Column<string>(type: "text", nullable: true),
                    LisenseVehicle = table.Column<string>(type: "text", nullable: true),
                    EntryTime = table.Column<string>(type: "text", nullable: true),
                    OutTime = table.Column<string>(type: "text", nullable: true),
                    ParkingCode = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: false),
                    ImageIn = table.Column<string>(type: "text", nullable: true),
                    ImageOut = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillsId);
                    table.ForeignKey(
                        name: "FK_Bills_EntryVehicles_LisenseVehicle",
                        column: x => x.LisenseVehicle,
                        principalTable: "EntryVehicles",
                        principalColumn: "LisenseVehicle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Parkings_ParkingCode",
                        column: x => x.ParkingCode,
                        principalTable: "Parkings",
                        principalColumn: "ParkingCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_LisenseVehicle",
                table: "Bills",
                column: "LisenseVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ParkingCode",
                table: "Bills",
                column: "ParkingCode");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVehicles_ParkingCode",
                table: "EntryVehicles",
                column: "ParkingCode");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVehicles_Username",
                table: "EntryVehicles",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Managements_ParkingCode",
                table: "Managements",
                column: "ParkingCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Managements");

            migrationBuilder.DropTable(
                name: "EntryVehicles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
