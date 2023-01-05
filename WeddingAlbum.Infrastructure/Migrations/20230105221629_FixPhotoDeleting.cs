using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class FixPhotoDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoInAlbum_Photo_PhotoId",
                table: "PhotoInAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoInAlbum_Photo_PhotoId",
                table: "PhotoInAlbum",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoInAlbum_Photo_PhotoId",
                table: "PhotoInAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoInAlbum_Photo_PhotoId",
                table: "PhotoInAlbum",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");
        }
    }
}
