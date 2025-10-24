using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKehoachKPi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GiaTriThucHien",
                table: "AppMucTieuKpis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaTriMucTieu",
                table: "AppMucTieuKpis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoMucTieu",
                table: "AppKeHoachCongViecs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoMucTieu",
                table: "AppKeHoachCongViecs");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaTriThucHien",
                table: "AppMucTieuKpis",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaTriMucTieu",
                table: "AppMucTieuKpis",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
