using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class AddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Photo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "Date",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Comment");
        }
    }
}
