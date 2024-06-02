using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilkyProject.Data.Migrations
{
    public partial class start6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressMapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSalePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SiteSocialMedias",
                columns: table => new
                {
                    SiteSocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteSocialMediaLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteSocialMediaIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSocialMedias", x => x.SiteSocialMediaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SiteSocialMedias");
        }
    }
}
