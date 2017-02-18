using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidisc2.Migrations
{
    public partial class Changedcoursemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Rounds",
                newName: "StartedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Rounds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "Rounds",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Rounds",
                nullable: false,
                defaultValue: false);
        }
    }
}
