using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class AddLikesToCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Comment");
        }
    }
}
