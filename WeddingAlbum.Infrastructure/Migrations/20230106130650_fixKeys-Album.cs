using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class fixKeysAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "MainPhotoId",
                table: "Album",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "MainPhotoId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
