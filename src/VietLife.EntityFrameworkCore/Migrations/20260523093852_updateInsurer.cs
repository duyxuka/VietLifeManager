using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class updateInsurer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBaiViets_AppDanhMucs_DanhMucId",
                table: "AppBaiViets");

            migrationBuilder.DropColumn(
                name: "AnhDaiDien",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "MoTaNgan",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "ColIndex",
                table: "AppNhoms");

            migrationBuilder.RenameColumn(
                name: "NoiDung",
                table: "AppSanPhamInsurers",
                newName: "TaiLieu");

            migrationBuilder.RenameColumn(
                name: "DanhMucId",
                table: "AppBaiViets",
                newName: "NhomId");

            migrationBuilder.RenameIndex(
                name: "IX_AppBaiViets_DanhMucId",
                table: "AppBaiViets",
                newName: "IX_AppBaiViets_NhomId");

            migrationBuilder.AddColumn<string>(
                name: "BieuPhi",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DangKy",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuyenMai",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuyenLoi",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "AppNhoms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NhomId",
                table: "AppDangKyTuVans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDangKyTuVans_NhomId",
                table: "AppDangKyTuVans",
                column: "NhomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBaiViets_AppNhoms_NhomId",
                table: "AppBaiViets",
                column: "NhomId",
                principalTable: "AppNhoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDangKyTuVans_AppNhoms_NhomId",
                table: "AppDangKyTuVans",
                column: "NhomId",
                principalTable: "AppNhoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBaiViets_AppNhoms_NhomId",
                table: "AppBaiViets");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDangKyTuVans_AppNhoms_NhomId",
                table: "AppDangKyTuVans");

            migrationBuilder.DropIndex(
                name: "IX_AppDangKyTuVans_NhomId",
                table: "AppDangKyTuVans");

            migrationBuilder.DropColumn(
                name: "BieuPhi",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "DangKy",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "KhuyenMai",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "QuyenLoi",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "AppNhoms");

            migrationBuilder.DropColumn(
                name: "NhomId",
                table: "AppDangKyTuVans");

            migrationBuilder.RenameColumn(
                name: "TaiLieu",
                table: "AppSanPhamInsurers",
                newName: "NoiDung");

            migrationBuilder.RenameColumn(
                name: "NhomId",
                table: "AppBaiViets",
                newName: "DanhMucId");

            migrationBuilder.RenameIndex(
                name: "IX_AppBaiViets_NhomId",
                table: "AppBaiViets",
                newName: "IX_AppBaiViets_DanhMucId");

            migrationBuilder.AddColumn<string>(
                name: "AnhDaiDien",
                table: "AppSanPhamInsurers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTaNgan",
                table: "AppSanPhamInsurers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColIndex",
                table: "AppNhoms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppBaiViets_AppDanhMucs_DanhMucId",
                table: "AppBaiViets",
                column: "DanhMucId",
                principalTable: "AppDanhMucs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
