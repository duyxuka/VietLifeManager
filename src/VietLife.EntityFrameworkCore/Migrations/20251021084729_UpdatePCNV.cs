using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePCNV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppPhuCapNhanViens_NhanVienId",
                table: "AppPhuCapNhanViens");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "AppPhuCapNhanViens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NhanVienId",
                table: "AppPhuCapNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPhuCapNhanViens_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhuCapNhanViens_AbpUsers_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
