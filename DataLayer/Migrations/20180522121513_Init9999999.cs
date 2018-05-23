using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Init9999999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bigPreview",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "smallPreview",
                table: "Pages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bigPreview",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "smallPreview",
                table: "Pages");
        }
    }
}
