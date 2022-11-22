using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorWeb.Models;

namespace RazorWeb.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });


            //Fake data : Bogus
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 7, 1)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));


            for (int i = 0; i < 150; i++)
            {
                var article = fakerArticle.Generate();
                migrationBuilder.InsertData("Article"
                , new[] { "Title", "Created", "Content" }
                , new object[]
                {
                        article.Title,
                        article.Created,
                        article.Content
                });
            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
