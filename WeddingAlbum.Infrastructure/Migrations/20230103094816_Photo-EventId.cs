using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class PhotoEventId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Photo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_EventId",
                table: "Photo",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Event_EventId",
                table: "Photo",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Event_EventId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_EventId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Photo");
        }
    }
}
