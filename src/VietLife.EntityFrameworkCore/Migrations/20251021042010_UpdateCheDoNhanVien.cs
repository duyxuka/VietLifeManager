using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCheDoNhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppChiNhanhs_ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppPhongBans_PhongBanId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppCheDoNhanViens_ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppCheDoNhanViens_PhongBanId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "AppCheDoNhanViens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChiNhanhId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBanId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCheDoNhanViens_ChiNhanhId",
                table: "AppCheDoNhanViens",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCheDoNhanViens_PhongBanId",
                table: "AppCheDoNhanViens",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppChiNhanhs_ChiNhanhId",
                table: "AppCheDoNhanViens",
                column: "ChiNhanhId",
                principalTable: "AppChiNhanhs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppPhongBans_PhongBanId",
                table: "AppCheDoNhanViens",
                column: "PhongBanId",
                principalTable: "AppPhongBans",
                principalColumn: "Id");
        }
    }
}
