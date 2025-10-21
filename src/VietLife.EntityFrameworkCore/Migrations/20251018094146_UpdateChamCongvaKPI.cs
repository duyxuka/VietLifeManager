using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChamCongvaKPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLichLamViecs_AbpUsers_NhanVienId",
                table: "AppLichLamViecs");

            migrationBuilder.DropTable(
                name: "AppNghiPheps");

            migrationBuilder.DropTable(
                name: "AppLoaiNghis");

            migrationBuilder.DropIndex(
                name: "IX_AppLichLamViecs_NhanVienId",
                table: "AppLichLamViecs");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "AppLichLamViecs");

            migrationBuilder.DropColumn(
                name: "DiMuon",
                table: "AppChamCongs");

            migrationBuilder.DropColumn(
                name: "VeSom",
                table: "AppChamCongs");

            migrationBuilder.RenameColumn(
                name: "GioKetThuc",
                table: "AppLichLamViecs",
                newName: "GioKetThucMacDinh");

            migrationBuilder.RenameColumn(
                name: "GioBatDau",
                table: "AppLichLamViecs",
                newName: "GioBatDauMacDinh");

            migrationBuilder.RenameColumn(
                name: "CaLam",
                table: "AppLichLamViecs",
                newName: "CaLamMacDinh");

            migrationBuilder.RenameColumn(
                name: "LoaiCheDo",
                table: "AppCheDoNhanViens",
                newName: "LyDo");

            migrationBuilder.AddColumn<decimal>(
                name: "CongTruCheDo",
                table: "AppLuongNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgayLam",
                table: "AppLichLamViecs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Nam",
                table: "AppLichLamViecs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NgayNghi",
                table: "AppLichLamViecs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thang",
                table: "AppLichLamViecs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MucLuongKpi",
                table: "AppKpiNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PhanTramHoanThanh",
                table: "AppKpiNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChiNhanhId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiCheDoId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NguoiDuyetId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBanId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoCong",
                table: "AppCheDoNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoNgay",
                table: "AppCheDoNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThanhTien",
                table: "AppCheDoNhanViens",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrangThai",
                table: "AppCheDoNhanViens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "TrangThai",
                table: "AppChamCongs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CongNgay",
                table: "AppChamCongs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoPhutDiMuon",
                table: "AppChamCongs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoPhutVeSom",
                table: "AppChamCongs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChiNhanhId",
                table: "AbpUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppChiNhanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppChiNhanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDanhGiaKpis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiNhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiemDanhGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NhanXet = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NguoiDanhGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AppDanhGiaKpis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDanhGiaKpis_AppKpiNhanViens_KpiNhanVienId",
                        column: x => x.KpiNhanVienId,
                        principalTable: "AppKpiNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppKeHoachCongViecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiNhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKeHoach = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrongSo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_AppKeHoachCongViecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppKeHoachCongViecs_AppKpiNhanViens_KpiNhanVienId",
                        column: x => x.KpiNhanVienId,
                        principalTable: "AppKpiNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppLoaiCheDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiCheDo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HeSoCong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppLoaiCheDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTienDoLamViecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiNhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTramTienDo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_AppTienDoLamViecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTienDoLamViecs_AppKpiNhanViens_KpiNhanVienId",
                        column: x => x.KpiNhanVienId,
                        principalTable: "AppKpiNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppMucTieuKpis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiNhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMucTieu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GiaTriMucTieu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrongSo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KeHoachCongViecId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AppMucTieuKpis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMucTieuKpis_AppKeHoachCongViecs_KeHoachCongViecId",
                        column: x => x.KeHoachCongViecId,
                        principalTable: "AppKeHoachCongViecs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppMucTieuKpis_AppKpiNhanViens_KpiNhanVienId",
                        column: x => x.KpiNhanVienId,
                        principalTable: "AppKpiNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCheDoNhanViens_ChiNhanhId",
                table: "AppCheDoNhanViens",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCheDoNhanViens_LoaiCheDoId",
                table: "AppCheDoNhanViens",
                column: "LoaiCheDoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCheDoNhanViens_PhongBanId",
                table: "AppCheDoNhanViens",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ChiNhanhId",
                table: "AbpUsers",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDanhGiaKpis_KpiNhanVienId",
                table: "AppDanhGiaKpis",
                column: "KpiNhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_AppKeHoachCongViecs_KpiNhanVienId",
                table: "AppKeHoachCongViecs",
                column: "KpiNhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMucTieuKpis_KeHoachCongViecId",
                table: "AppMucTieuKpis",
                column: "KeHoachCongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMucTieuKpis_KpiNhanVienId",
                table: "AppMucTieuKpis",
                column: "KpiNhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTienDoLamViecs_KpiNhanVienId",
                table: "AppTienDoLamViecs",
                column: "KpiNhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppChiNhanhs_ChiNhanhId",
                table: "AbpUsers",
                column: "ChiNhanhId",
                principalTable: "AppChiNhanhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppChiNhanhs_ChiNhanhId",
                table: "AppCheDoNhanViens",
                column: "ChiNhanhId",
                principalTable: "AppChiNhanhs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppLoaiCheDos_LoaiCheDoId",
                table: "AppCheDoNhanViens",
                column: "LoaiCheDoId",
                principalTable: "AppLoaiCheDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCheDoNhanViens_AppPhongBans_PhongBanId",
                table: "AppCheDoNhanViens",
                column: "PhongBanId",
                principalTable: "AppPhongBans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppChiNhanhs_ChiNhanhId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppChiNhanhs_ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppLoaiCheDos_LoaiCheDoId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCheDoNhanViens_AppPhongBans_PhongBanId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropTable(
                name: "AppChiNhanhs");

            migrationBuilder.DropTable(
                name: "AppDanhGiaKpis");

            migrationBuilder.DropTable(
                name: "AppLoaiCheDos");

            migrationBuilder.DropTable(
                name: "AppMucTieuKpis");

            migrationBuilder.DropTable(
                name: "AppTienDoLamViecs");

            migrationBuilder.DropTable(
                name: "AppKeHoachCongViecs");

            migrationBuilder.DropIndex(
                name: "IX_AppCheDoNhanViens_ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppCheDoNhanViens_LoaiCheDoId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AppCheDoNhanViens_PhongBanId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ChiNhanhId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CongTruCheDo",
                table: "AppLuongNhanViens");

            migrationBuilder.DropColumn(
                name: "Nam",
                table: "AppLichLamViecs");

            migrationBuilder.DropColumn(
                name: "NgayNghi",
                table: "AppLichLamViecs");

            migrationBuilder.DropColumn(
                name: "Thang",
                table: "AppLichLamViecs");

            migrationBuilder.DropColumn(
                name: "MucLuongKpi",
                table: "AppKpiNhanViens");

            migrationBuilder.DropColumn(
                name: "PhanTramHoanThanh",
                table: "AppKpiNhanViens");

            migrationBuilder.DropColumn(
                name: "ChiNhanhId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "LoaiCheDoId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "NguoiDuyetId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "SoCong",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "SoNgay",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "AppCheDoNhanViens");

            migrationBuilder.DropColumn(
                name: "CongNgay",
                table: "AppChamCongs");

            migrationBuilder.DropColumn(
                name: "SoPhutDiMuon",
                table: "AppChamCongs");

            migrationBuilder.DropColumn(
                name: "SoPhutVeSom",
                table: "AppChamCongs");

            migrationBuilder.DropColumn(
                name: "ChiNhanhId",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "GioKetThucMacDinh",
                table: "AppLichLamViecs",
                newName: "GioKetThuc");

            migrationBuilder.RenameColumn(
                name: "GioBatDauMacDinh",
                table: "AppLichLamViecs",
                newName: "GioBatDau");

            migrationBuilder.RenameColumn(
                name: "CaLamMacDinh",
                table: "AppLichLamViecs",
                newName: "CaLam");

            migrationBuilder.RenameColumn(
                name: "LyDo",
                table: "AppCheDoNhanViens",
                newName: "LoaiCheDo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayLam",
                table: "AppLichLamViecs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NhanVienId",
                table: "AppLichLamViecs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "AppChamCongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "DiMuon",
                table: "AppChamCongs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VeSom",
                table: "AppChamCongs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AppLoaiNghis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoNgayMacDinh = table.Column<int>(type: "int", nullable: false),
                    TenLoaiNghi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLoaiNghis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppNghiPheps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiNghiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LyDo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NguoiDuyetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNghiPheps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNghiPheps_AbpUsers_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppNghiPheps_AppLoaiNghis_LoaiNghiId",
                        column: x => x.LoaiNghiId,
                        principalTable: "AppLoaiNghis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppLichLamViecs_NhanVienId",
                table: "AppLichLamViecs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNghiPheps_LoaiNghiId",
                table: "AppNghiPheps",
                column: "LoaiNghiId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNghiPheps_NhanVienId",
                table: "AppNghiPheps",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLichLamViecs_AbpUsers_NhanVienId",
                table: "AppLichLamViecs",
                column: "NhanVienId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
