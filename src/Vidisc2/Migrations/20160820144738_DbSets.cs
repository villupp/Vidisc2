using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidisc2.Migrations
{
    public partial class DbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Course_CourseId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Scorecard_Player_PlayerId",
                table: "Scorecard");

            migrationBuilder.DropForeignKey(
                name: "FK_Scorecard_Rounds_RoundId",
                table: "Scorecard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scorecard",
                table: "Scorecard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scorecards",
                table: "Scorecard",
                column: "ScorecardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Player",
                column: "PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Courses_CourseId",
                table: "Rounds",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecards_Players_PlayerId",
                table: "Scorecard",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecards_Rounds_RoundId",
                table: "Scorecard",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Scorecard_RoundId",
                table: "Scorecard",
                newName: "IX_Scorecards_RoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Scorecard_PlayerId",
                table: "Scorecard",
                newName: "IX_Scorecards_PlayerId");

            migrationBuilder.RenameTable(
                name: "Scorecard",
                newName: "Scorecards");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Courses_CourseId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Scorecards_Players_PlayerId",
                table: "Scorecards");

            migrationBuilder.DropForeignKey(
                name: "FK_Scorecards_Rounds_RoundId",
                table: "Scorecards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scorecards",
                table: "Scorecards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scorecard",
                table: "Scorecards",
                column: "ScorecardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Course_CourseId",
                table: "Rounds",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecard_Player_PlayerId",
                table: "Scorecards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scorecard_Rounds_RoundId",
                table: "Scorecards",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Scorecards_RoundId",
                table: "Scorecards",
                newName: "IX_Scorecard_RoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Scorecards_PlayerId",
                table: "Scorecards",
                newName: "IX_Scorecard_PlayerId");

            migrationBuilder.RenameTable(
                name: "Scorecards",
                newName: "Scorecard");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");
        }
    }
}
