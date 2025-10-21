using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuanlynhansu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChamCongs_AppUsers_UserId",
                table: "AppChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppKpiNhanViens_AppUsers_UserId",
                table: "AppKpiNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLichLamViecs_AppUsers_UserId",
                table: "AppLichLamViecs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppLuongNhanViens_AppUsers_UserId",
                table: "AppLuongNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNghiPheps_AppUsers_UserId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNghiPheps_LoaiNghis_LoaiNghiId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AbpUsers_Id",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppChucVus_ChucVuId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppPhongBans_PhongBanId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CheDoNhanViens_AppUsers_NhanVienId",
                table: "CheDoNhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiNghis",
                table: "LoaiNghis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheDoNhanViens",
                table: "CheDoNhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CheDoNhanViens");

            migrationBuilder.RenameTable(
                name: "LoaiNghis",
                newName: "AppLoaiNghis");

            migrationBuilder.RenameTable(
                name: "CheDoNhanViens",
                newName: "AppCheDoNhanViens");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppNhanViens");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppNghiPheps",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppNghiPheps_UserId",
                table: "AppNghiPheps",
                newName: "IX_AppNghiPheps_NhanVienId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppLuongNhanViens",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppLuongNhanViens_UserId",
                table: "AppLuongNhanViens",
                newName: "IX_AppLuongNhanViens_NhanVienId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppLichLamViecs",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppLichLamViecs_UserId",
                table: "AppLichLamViecs",
                newName: "IX_AppLichLamViecs_NhanVienId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppKpiNhanViens",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppKpiNhanViens_UserId",
                table: "AppKpiNhanViens",
                newName: "IX_AppKpiNhanViens_NhanVienId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppChamCongs",
                newName: "NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppChamCongs_UserId",
                table: "AppChamCongs",
                newName: "IX_AppChamCongs_NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_CheDoNhanViens_NhanVienId",
                table: "AppCheDoNhanViens",
                newName: "IX_AppCheDoNhanViens_NhanVienId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_PhongBanId",
                table: "AppNhanViens",
                newName: "IX_AppNhanViens_PhongBanId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ChucVuId",
                table: "AppNhanViens",
                newName: "IX_AppNhanViens_ChucVuId");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "AppCheDoNhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLoaiNghis",
                table: "AppLoaiNghis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCheDoNhanViens",
                table: "AppCheDoNhanViens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppNhanViens",
                table: "AppNhanViens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppPhuCapNhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppPhuCapNhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPhuCapNhanViens_AppNhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "AppNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPhuCapNhanViens_NhanVienId",
                table: "AppPhuCapNhanViens",
                column: "NhanVienId");

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
                name: "FK_AppNghiPheps_AppLoaiNghis_LoaiNghiId",
                table: "AppNghiPheps",
                column: "LoaiNghiId",
                principalTable: "AppLoaiNghis",
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
                name: "FK_AppNhanViens_AbpUsers_Id",
                table: "AppNhanViens",
                column: "Id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNhanViens_AppChucVus_ChucVuId",
                table: "AppNhanViens",
                column: "ChucVuId",
                principalTable: "AppChucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNhanViens_AppPhongBans_PhongBanId",
                table: "AppNhanViens",
                column: "PhongBanId",
                principalTable: "AppPhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_AppNghiPheps_AppLoaiNghis_LoaiNghiId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNghiPheps_AppNhanViens_NhanVienId",
                table: "AppNghiPheps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNhanViens_AbpUsers_Id",
                table: "AppNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNhanViens_AppChucVus_ChucVuId",
                table: "AppNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNhanViens_AppPhongBans_PhongBanId",
                table: "AppNhanViens");

            migrationBuilder.DropTable(
                name: "AppPhuCapNhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppNhanViens",
                table: "AppNhanViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLoaiNghis",
                table: "AppLoaiNghis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCheDoNhanViens",
                table: "AppCheDoNhanViens");

            migrationBuilder.RenameTable(
                name: "AppNhanViens",
                newName: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppLoaiNghis",
                newName: "LoaiNghis");

            migrationBuilder.RenameTable(
                name: "AppCheDoNhanViens",
                newName: "CheDoNhanViens");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "AppNghiPheps",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppNghiPheps_NhanVienId",
                table: "AppNghiPheps",
                newName: "IX_AppNghiPheps_UserId");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "AppLuongNhanViens",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppLuongNhanViens_NhanVienId",
                table: "AppLuongNhanViens",
                newName: "IX_AppLuongNhanViens_UserId");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "AppLichLamViecs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppLichLamViecs_NhanVienId",
                table: "AppLichLamViecs",
                newName: "IX_AppLichLamViecs_UserId");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "AppKpiNhanViens",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppKpiNhanViens_NhanVienId",
                table: "AppKpiNhanViens",
                newName: "IX_AppKpiNhanViens_UserId");

            migrationBuilder.RenameColumn(
                name: "NhanVienId",
                table: "AppChamCongs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppChamCongs_NhanVienId",
                table: "AppChamCongs",
                newName: "IX_AppChamCongs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppNhanViens_PhongBanId",
                table: "AppUsers",
                newName: "IX_AppUsers_PhongBanId");

            migrationBuilder.RenameIndex(
                name: "IX_AppNhanViens_ChucVuId",
                table: "AppUsers",
                newName: "IX_AppUsers_ChucVuId");

            migrationBuilder.RenameIndex(
                name: "IX_AppCheDoNhanViens_NhanVienId",
                table: "CheDoNhanViens",
                newName: "IX_CheDoNhanViens_NhanVienId");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "CheDoNhanViens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CheDoNhanViens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiNghis",
                table: "LoaiNghis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheDoNhanViens",
                table: "CheDoNhanViens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppChamCongs_AppUsers_UserId",
                table: "AppChamCongs",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppKpiNhanViens_AppUsers_UserId",
                table: "AppKpiNhanViens",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLichLamViecs_AppUsers_UserId",
                table: "AppLichLamViecs",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLuongNhanViens_AppUsers_UserId",
                table: "AppLuongNhanViens",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNghiPheps_AppUsers_UserId",
                table: "AppNghiPheps",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNghiPheps_LoaiNghis_LoaiNghiId",
                table: "AppNghiPheps",
                column: "LoaiNghiId",
                principalTable: "LoaiNghis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AbpUsers_Id",
                table: "AppUsers",
                column: "Id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppChucVus_ChucVuId",
                table: "AppUsers",
                column: "ChucVuId",
                principalTable: "AppChucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppPhongBans_PhongBanId",
                table: "AppUsers",
                column: "PhongBanId",
                principalTable: "AppPhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CheDoNhanViens_AppUsers_NhanVienId",
                table: "CheDoNhanViens",
                column: "NhanVienId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
