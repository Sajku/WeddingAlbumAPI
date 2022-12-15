using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class EventAndUserInEventTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_OwnerUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Event");

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "UserInEvent",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "UserInEvent");

            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_OwnerUserId",
                table: "Event",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OwnerUserId",
                table: "Event",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
