using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingAlbum.Infrastructure.Migrations
{
    public partial class AddPhotoInAlbumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoInAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoInAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoInAlbum_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotoInAlbum_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoInAlbum_AlbumId",
                table: "PhotoInAlbum",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoInAlbum_PhotoId",
                table: "PhotoInAlbum",
                column: "PhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoInAlbum");
        }
    }
}
