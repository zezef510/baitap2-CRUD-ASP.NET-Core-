using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace baitap2_CRUD_.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    HocSinhID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<bool>(nullable: false),
                    Tuoi = table.Column<int>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    Luong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.HocSinhID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
