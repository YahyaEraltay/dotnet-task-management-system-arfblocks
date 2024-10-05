using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedStationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StationId",
                table: "TankGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TankGroups_StationId",
                table: "TankGroups",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TankGroups_Stations_StationId",
                table: "TankGroups",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TankGroups_Stations_StationId",
                table: "TankGroups");

            migrationBuilder.DropIndex(
                name: "IX_TankGroups_StationId",
                table: "TankGroups");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "TankGroups");
        }
    }
}
