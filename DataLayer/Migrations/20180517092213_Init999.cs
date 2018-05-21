using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Init999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Pages",
                newName: "SeoUrl");

            migrationBuilder.RenameColumn(
                name: "CustumUrl",
                table: "Pages",
                newName: "PageStyles");

            migrationBuilder.AddColumn<int>(
                name: "ItemsPerPage",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OpenDirectoryPagesWithAjax",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectoryId",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageScripts",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Pages_DirectoryId",
                table: "Pages",
                column: "DirectoryId");

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

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Pages_Pages_DirectoryId",
            //    table: "Pages",
            //    column: "DirectoryId",
            //    principalTable: "Pages",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_DirectoryId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "CustumFieldValues");

            migrationBuilder.DropTable(
                name: "CustumContent");

            migrationBuilder.DropTable(
                name: "CustumFields");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DirectoryId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ItemsPerPage",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "OpenDirectoryPagesWithAjax",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DirectoryId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageName",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageScripts",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "SeoUrl",
                table: "Pages",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PageStyles",
                table: "Pages",
                newName: "CustumUrl");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    WidgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TypeString = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ContentId",
                table: "Fields",
                column: "ContentId");
        }
    }
}
