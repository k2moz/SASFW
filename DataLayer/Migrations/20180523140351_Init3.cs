using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustumFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustumFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ItemsPerPage = table.Column<int>(nullable: true),
                    OpenDirectoryPagesWithAjax = table.Column<bool>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    DirectoryId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: true),
                    PageHtml = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageScripts = table.Column<string>(nullable: true),
                    PageStyles = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    SeoUrl = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    bigPreview = table.Column<string>(nullable: true),
                    smallPreview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    /*table.ForeignKey(
                        name: "FK_Pages_Pages_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);*/
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustumContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustumContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustumContent_Pages_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustumFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustumContentId = table.Column<int>(nullable: false),
                    CustumFieldId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustumFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustumFieldValues_CustumContent_CustumContentId",
                        column: x => x.CustumContentId,
                        principalTable: "CustumContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustumFieldValues_CustumFields_CustumFieldId",
                        column: x => x.CustumFieldId,
                        principalTable: "CustumFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustumContent_MaterialId",
                table: "CustumContent",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CustumFieldValues_CustumContentId",
                table: "CustumFieldValues",
                column: "CustumContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustumFieldValues_CustumFieldId",
                table: "CustumFieldValues",
                column: "CustumFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DirectoryId",
                table: "Pages",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustumFieldValues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CustumContent");

            migrationBuilder.DropTable(
                name: "CustumFields");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
