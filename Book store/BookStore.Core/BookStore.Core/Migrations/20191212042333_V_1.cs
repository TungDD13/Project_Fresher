using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Core.Migrations
{
    public partial class V_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateName = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubName = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PubId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    CateId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true),
                    PubId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CateId",
                        column: x => x.CateId,
                        principalTable: "Categories",
                        principalColumn: "CateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PubId",
                        column: x => x.PubId,
                        principalTable: "Publishers",
                        principalColumn: "PubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CateId", "CateName", "Description" },
                values: new object[,]
                {
                    { 1, "Anime", "this is a Description 1" },
                    { 2, "Viet Nam", "this is a Description 2" },
                    { 3, "Dan Gian", "this is a Description 3" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PubId", "Description", "PubName" },
                values: new object[,]
                {
                    { 1, "he is a publisher", "Doan Tung" },
                    { 2, "he is a publisher 2", "Doan Tung 2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "CateId", "CreateDate", "ImgUrl", "IsActive", "ModifieDate", "Price", "PubId", "Quantity", "Summary", "Title" },
                values: new object[] { 1, null, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Image 1", true, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1, 50, "Summary 1", "Title 1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BookId", "Content", "CreateDate", "IsActive" },
                values: new object[] { 1, 1, "this is perfect", new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BookId", "Content", "CreateDate", "IsActive" },
                values: new object[] { 2, 1, "this is good", new DateTime(2019, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CateId",
                table: "Books",
                column: "CateId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PubId",
                table: "Books",
                column: "PubId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
