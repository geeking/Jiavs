using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jiavs.Infrastructure.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    WeChat = table.Column<string>(nullable: true),
                    QQ = table.Column<string>(nullable: true),
                    Level = table.Column<short>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<uint>(nullable: true),
                    Status_VisitCount = table.Column<int>(nullable: false),
                    Status_IsPublished = table.Column<bool>(nullable: false),
                    Status_PublishTime = table.Column<DateTime>(nullable: true),
                    Status_CreatedTime = table.Column<DateTime>(nullable: false),
                    Status_ModifyTime = table.Column<DateTime>(nullable: false),
                    Status_IsOriginal = table.Column<bool>(nullable: false),
                    Status_ClassificationId = table.Column<int>(nullable: false),
                    Status_Deleted = table.Column<bool>(nullable: false),
                    Status_DeletedTime = table.Column<DateTime>(nullable: true),
                    Settings_CanComment = table.Column<bool>(nullable: false),
                    Settings_CanGrade = table.Column<bool>(nullable: false),
                    Content_Title = table.Column<string>(nullable: true),
                    Content_CoverUrl = table.Column<string>(nullable: true),
                    Content_Summary = table.Column<string>(nullable: true),
                    Content_ContentHtml = table.Column<string>(nullable: true),
                    Content_ContentMarkdown = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
