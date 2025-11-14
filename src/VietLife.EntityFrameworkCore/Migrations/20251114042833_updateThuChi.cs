using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class updateThuChi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AppKhachHangs_KhachHangId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "LaThu",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "TaiKhoanNoId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "TaiKhoanCoId",
                table: "AppThuChis");

            // 2. Thêm các cột mới
            migrationBuilder.AddColumn<Guid>(
                name: "TaiKhoanNoId",
                table: "AppThuChis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaiKhoanCoId",
                table: "AppThuChis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "AppThuChis",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DoiTuongId",
                table: "AppThuChis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiDoiTuong",
                table: "AppThuChis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiThuChiId",
                table: "AppThuChis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LyDoHuy",
                table: "AppThuChis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDuyet",
                table: "AppThuChis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHachToan",
                table: "AppThuChis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHoaDon",
                table: "AppThuChis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiDuyetId",
                table: "AppThuChis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhuongThucThanhToan",
                table: "AppThuChis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SoHoaDon",
                table: "AppThuChis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoTaiKhoanNganHang",
                table: "AppThuChis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppThuChis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenNganHang",
                table: "AppThuChis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThanhTienSauThue",
                table: "AppThuChis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThueSuat",
                table: "AppThuChis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TienThue",
                table: "AppThuChis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppLoaiThuChis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsThu = table.Column<bool>(type: "bit", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLoaiThuChis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTaiKhoanKeToans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTaiKhoanKeToans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppThuChis_LoaiThuChiId",
                table: "AppThuChis",
                column: "LoaiThuChiId");

            migrationBuilder.CreateIndex(
                name: "IX_AppThuChis_NguoiDuyetId",
                table: "AppThuChis",
                column: "NguoiDuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppThuChis_TaiKhoanCoId",
                table: "AppThuChis",
                column: "TaiKhoanCoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppThuChis_TaiKhoanNoId",
                table: "AppThuChis",
                column: "TaiKhoanNoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AbpUsers_NguoiDuyetId",
                table: "AppThuChis",
                column: "NguoiDuyetId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AppKhachHangs_KhachHangId",
                table: "AppThuChis",
                column: "KhachHangId",
                principalTable: "AppKhachHangs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AppLoaiThuChis_LoaiThuChiId",
                table: "AppThuChis",
                column: "LoaiThuChiId",
                principalTable: "AppLoaiThuChis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AppTaiKhoanKeToans_TaiKhoanCoId",
                table: "AppThuChis",
                column: "TaiKhoanCoId",
                principalTable: "AppTaiKhoanKeToans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AppTaiKhoanKeToans_TaiKhoanNoId",
                table: "AppThuChis",
                column: "TaiKhoanNoId",
                principalTable: "AppTaiKhoanKeToans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AbpUsers_NguoiDuyetId",
                table: "AppThuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AppKhachHangs_KhachHangId",
                table: "AppThuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AppLoaiThuChis_LoaiThuChiId",
                table: "AppThuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AppTaiKhoanKeToans_TaiKhoanCoId",
                table: "AppThuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_AppThuChis_AppTaiKhoanKeToans_TaiKhoanNoId",
                table: "AppThuChis");

            migrationBuilder.DropTable(
                name: "AppLoaiThuChis");

            migrationBuilder.DropTable(
                name: "AppTaiKhoanKeToans");

            migrationBuilder.DropIndex(
                name: "IX_AppThuChis_LoaiThuChiId",
                table: "AppThuChis");

            migrationBuilder.DropIndex(
                name: "IX_AppThuChis_NguoiDuyetId",
                table: "AppThuChis");

            migrationBuilder.DropIndex(
                name: "IX_AppThuChis_TaiKhoanCoId",
                table: "AppThuChis");

            migrationBuilder.DropIndex(
                name: "IX_AppThuChis_TaiKhoanNoId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "DoiTuongId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "LoaiDoiTuong",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "LoaiThuChiId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "LyDoHuy",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "NgayDuyet",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "NgayHachToan",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "NgayHoaDon",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "NguoiDuyetId",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "SoHoaDon",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "SoTaiKhoanNganHang",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "TenNganHang",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "ThanhTienSauThue",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "ThueSuat",
                table: "AppThuChis");

            migrationBuilder.DropColumn(
                name: "TienThue",
                table: "AppThuChis");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanNoId",
                table: "AppThuChis",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanCoId",
                table: "AppThuChis",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LaThu",
                table: "AppThuChis",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppThuChis_AppKhachHangs_KhachHangId",
                table: "AppThuChis",
                column: "KhachHangId",
                principalTable: "AppKhachHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
