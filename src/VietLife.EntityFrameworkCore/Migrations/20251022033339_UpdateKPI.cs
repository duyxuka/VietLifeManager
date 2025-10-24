using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMucTieuKpis_AppKeHoachCongViecs_KeHoachCongViecId",
                table: "AppMucTieuKpis");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTriThucHien",
                table: "AppMucTieuKpis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppMucTieuKpis_AppKeHoachCongViecs_KeHoachCongViecId",
                table: "AppMucTieuKpis",
                column: "KeHoachCongViecId",
                principalTable: "AppKeHoachCongViecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMucTieuKpis_AppKeHoachCongViecs_KeHoachCongViecId",
                table: "AppMucTieuKpis");

            migrationBuilder.DropColumn(
                name: "GiaTriThucHien",
                table: "AppMucTieuKpis");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMucTieuKpis_AppKeHoachCongViecs_KeHoachCongViecId",
                table: "AppMucTieuKpis",
                column: "KeHoachCongViecId",
                principalTable: "AppKeHoachCongViecs",
                principalColumn: "Id");
        }
    }
}
