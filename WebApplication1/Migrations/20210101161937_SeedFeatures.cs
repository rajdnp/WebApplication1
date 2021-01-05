using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Features values('Feature 1')");
            migrationBuilder.Sql("insert into Features values('Feature 2')");
            migrationBuilder.Sql("insert into Features values('Feature 3')");
            migrationBuilder.Sql("insert into Features values('Feature 4')");
            migrationBuilder.Sql("insert into Features values('Feature 5')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Features");
        }
    }
}
