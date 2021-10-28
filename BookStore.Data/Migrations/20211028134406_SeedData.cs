using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Authors (Name, CreateAt) Values ('Dan Brown', '2021-10-28 12:35:29')");
            migrationBuilder
                .Sql("INSERT INTO Authors (Name, CreateAt) Values ('Terry Brooks', '2021-10-28 12:35:29')");

            migrationBuilder
                .Sql("INSERT INTO Books (Title, Year, CreateAt, AuthorId) Values ('Deception point', '1998', '2021-10-28 12:35:29', (SELECT Id FROM Authors WHERE Name = 'Dan Brown'))");
            migrationBuilder
                .Sql("INSERT INTO Books (Title, Year, CreateAt, AuthorId) Values ('Magic staff', '2000', '2021-10-28 12:35:29', (SELECT Id FROM Authors WHERE Name = 'Terry Brooks'))");
            migrationBuilder
                .Sql("INSERT INTO Books (Title, Year, CreateAt, AuthorId) Values ('Bloodfire Quest', '2002', '2021-10-28 12:35:29', (SELECT Id FROM Authors WHERE Name = 'Terry Brooks'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Books");
            migrationBuilder.Sql("DELETE FROM Authors");
        }
    }
}
