using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietLife.Migrations
{
    /// <inheritdoc />
    public partial class AddSeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "AppSanPhamInsurers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "AppNhoms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "AppNhoms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "AppNhoms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "AppBaiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "AppBaiViets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "AppBaiViets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "AppSanPhamInsurers");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "AppNhoms");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "AppNhoms");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "AppNhoms");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "AppBaiViets");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "AppBaiViets");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "AppBaiViets");
        }
    }
}
