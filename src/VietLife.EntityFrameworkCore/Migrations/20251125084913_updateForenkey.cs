using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class updateForenkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietBaoGias_AppBaoGias_BaoGiaId",
                table: "AppChiTietBaoGias");

            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietDonHangs_AppDonHangs_DonHangId",
                table: "AppChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietPhieuNhapXuats_AppPhieuNhapXuats_PhieuNhapXuatId",
                table: "AppChiTietPhieuNhapXuats");

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "AppKhachHangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietBaoGias_AppBaoGias_BaoGiaId",
                table: "AppChiTietBaoGias",
                column: "BaoGiaId",
                principalTable: "AppBaoGias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietDonHangs_AppDonHangs_DonHangId",
                table: "AppChiTietDonHangs",
                column: "DonHangId",
                principalTable: "AppDonHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietPhieuNhapXuats_AppPhieuNhapXuats_PhieuNhapXuatId",
                table: "AppChiTietPhieuNhapXuats",
                column: "PhieuNhapXuatId",
                principalTable: "AppPhieuNhapXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietBaoGias_AppBaoGias_BaoGiaId",
                table: "AppChiTietBaoGias");

            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietDonHangs_AppDonHangs_DonHangId",
                table: "AppChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppChiTietPhieuNhapXuats_AppPhieuNhapXuats_PhieuNhapXuatId",
                table: "AppChiTietPhieuNhapXuats");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "AppKhachHangs");

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietBaoGias_AppBaoGias_BaoGiaId",
                table: "AppChiTietBaoGias",
                column: "BaoGiaId",
                principalTable: "AppBaoGias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietDonHangs_AppDonHangs_DonHangId",
                table: "AppChiTietDonHangs",
                column: "DonHangId",
                principalTable: "AppDonHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChiTietPhieuNhapXuats_AppPhieuNhapXuats_PhieuNhapXuatId",
                table: "AppChiTietPhieuNhapXuats",
                column: "PhieuNhapXuatId",
                principalTable: "AppPhieuNhapXuats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
