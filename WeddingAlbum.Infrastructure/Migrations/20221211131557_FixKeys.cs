using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class FixKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Photo_PhotoId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_User_UserId",
                table: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Photo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Photo_PhotoId",
                table: "Comment",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_User_UserId",
                table: "Photo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Photo_PhotoId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_User_UserId",
                table: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Photo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_MainPhotoId",
                table: "Album",
                column: "MainPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Photo_PhotoId",
                table: "Comment",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_User_UserId",
                table: "Photo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
