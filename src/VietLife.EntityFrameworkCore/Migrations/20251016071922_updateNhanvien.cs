using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class updateNhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChamCongs_AppNhanViens_NhanVienId",
                table: "AppChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppNhanViens_NhanVienId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppKpiNhanViens_AppNhanViens_NhanVienId",
                table: "AppKpiNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLichLamViecs_AppNhanViens_NhanVienId",
                table: "AppLichLamViecs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLuongNhanViens_AppNhanViens_NhanVienId",
                table: "AppLuongNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNghiPheps_AppNhanViens_NhanVienId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AppNhanViens_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropTable(
                name: "AppNhanViens");

            migrationBuilder.AddColumn<Guid>(
                name: "ChucVuId",
                table: "AbpUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "AbpUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "GioiTinh",
                table: "AbpUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "AbpUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNv",
                table: "AbpUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapCmnd",
                table: "AbpUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "AbpUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayVaoLam",
                table: "AbpUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiCapCmnd",
                table: "AbpUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBanId",
                table: "AbpUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoCmnd",
                table: "AbpUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "AbpUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ChucVuId",
                table: "AbpUsers",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_PhongBanId",
                table: "AbpUsers",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppChucVus_ChucVuId",
                table: "AbpUsers",
                column: "ChucVuId",
                principalTable: "AppChucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppPhongBans_PhongBanId",
                table: "AbpUsers",
                column: "PhongBanId",
                principalTable: "AppPhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChamCongs_AbpUsers_NhanVienId",
                table: "AppChamCongs",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AbpUsers_NhanVienId",
                table: "AppCheDoNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppKpiNhanViens_AbpUsers_NhanVienId",
                table: "AppKpiNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLichLamViecs_AbpUsers_NhanVienId",
                table: "AppLichLamViecs",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLuongNhanViens_AbpUsers_NhanVienId",
                table: "AppLuongNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNghiPheps_AbpUsers_NhanVienId",
                table: "AppNghiPheps",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppChucVus_ChucVuId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppPhongBans_PhongBanId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppChamCongs_AbpUsers_NhanVienId",
                table: "AppChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AbpUsers_NhanVienId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppKpiNhanViens_AbpUsers_NhanVienId",
                table: "AppKpiNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLichLamViecs_AbpUsers_NhanVienId",
                table: "AppLichLamViecs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLuongNhanViens_AbpUsers_NhanVienId",
                table: "AppLuongNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNghiPheps_AbpUsers_NhanVienId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ChucVuId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_PhongBanId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ChucVuId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MaNv",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NgayCapCmnd",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NgayVaoLam",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NoiCapCmnd",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "SoCmnd",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "AbpUsers");

            migrationBuilder.CreateTable(
                name: "AppNhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaNv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayCapCmnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoiCapCmnd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoCmnd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNhanViens_AbpUsers_Id",
                        column: x => x.Id,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppNhanViens_AppChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "AppChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AppNhanViens_AppPhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "AppPhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNhanViens_ChucVuId",
                table: "AppNhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNhanViens_PhongBanId",
                table: "AppNhanViens",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppChamCongs_AppNhanViens_NhanVienId",
                table: "AppChamCongs",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppNhanViens_NhanVienId",
                table: "AppCheDoNhanViens",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppKpiNhanViens_AppNhanViens_NhanVienId",
                table: "AppKpiNhanViens",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLichLamViecs_AppNhanViens_NhanVienId",
                table: "AppLichLamViecs",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLuongNhanViens_AppNhanViens_NhanVienId",
                table: "AppLuongNhanViens",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNghiPheps_AppNhanViens_NhanVienId",
                table: "AppNghiPheps",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AppNhanViens_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId",
                principalTable: "AppNhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
