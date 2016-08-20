using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidisc2.Migrations
{
    public partial class ScoreSetUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreSet",
                table: "Scorecards");

            migrationBuilder.AddColumn<string>(
                name: "ScoreSetStr",
                table: "Scorecards",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreSetStr",
                table: "Scorecards");

            migrationBuilder.AddColumn<string>(
                name: "ScoreSet",
                table: "Scorecards",
                nullable: false,
                defaultValue: "");
        }
    }
}
