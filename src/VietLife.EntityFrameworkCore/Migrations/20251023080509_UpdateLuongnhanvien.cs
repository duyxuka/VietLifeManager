using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLuongnhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuongCoBan",
                table: "AppLuongNhanViens");

            migrationBuilder.AddColumn<decimal>(
                name: "DonGiaCong",
                table: "AbpUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LuongCoBan",
                table: "AbpUsers",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonGiaCong",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LuongCoBan",
                table: "AbpUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "LuongCoBan",
                table: "AppLuongNhanViens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
