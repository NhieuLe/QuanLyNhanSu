using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanSuAPI.Migrations
{
    /// <inheritdoc />
    public partial class QLNS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongViecs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenCongViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CongViecId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongViecs_CongViecs_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "CongViecs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanSus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhongBanId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanSus_PhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanCongs",
                columns: table => new
                {
                    MaNhanSu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCongViec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NgayBD = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgayKT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CongViecId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongs", x => new { x.MaNhanSu, x.MaCongViec });
                    table.ForeignKey(
                        name: "FK_PhanCongs_CongViecs_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "CongViecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCongs_NhanSus_MaNhanSu",
                        column: x => x.MaNhanSu,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongViecs_CongViecId",
                table: "CongViecs",
                column: "CongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanSus_PhongBanId",
                table: "NhanSus",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_CongViecId",
                table: "PhanCongs",
                column: "CongViecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanCongs");

            migrationBuilder.DropTable(
                name: "CongViecs");

            migrationBuilder.DropTable(
                name: "NhanSus");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
