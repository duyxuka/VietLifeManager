using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhuCapNhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropColumn(
                name: "Nam",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropColumn(
                name: "Thang",
                table: "AppPhuCapNhanViens");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "AppPhuCapNhanViens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ChucVuId",
                table: "AppPhuCapNhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppPhuCapNhanViens_ChucVuId",
                table: "AppPhuCapNhanViens",
                column: "ChucVuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AppChucVus_ChucVuId",
                table: "AppPhuCapNhanViens",
                column: "ChucVuId",
                principalTable: "AppChucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AppChucVus_ChucVuId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppPhuCapNhanViens_ChucVuId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropColumn(
                name: "ChucVuId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "AppPhuCapNhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nam",
                table: "AppPhuCapNhanViens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Thang",
                table: "AppPhuCapNhanViens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
