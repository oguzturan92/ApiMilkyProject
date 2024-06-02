using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilkyProject.Data.Migrations
{
    public partial class start5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestimonialComment",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestimonialComment",
                table: "Testimonials");
        }
    }
}
