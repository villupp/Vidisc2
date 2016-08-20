using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidisc2.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holes",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "HolesStr",
                table: "Courses",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolesStr",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Holes",
                table: "Courses",
                nullable: false,
                defaultValue: "");
        }
    }
}
