using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Makes values ('Make1')");
            migrationBuilder.Sql("insert into Makes values ('Make2')");
            migrationBuilder.Sql("insert into Makes values ('Make3')");

            migrationBuilder.Sql("insert into Models values ('Make1-ModelA',1)");
            migrationBuilder.Sql("insert into Models values ('Make1-ModelB',1)");
            migrationBuilder.Sql("insert into Models values ('Make1-ModelC',1)");
            migrationBuilder.Sql("insert into Models values ('Make1-ModelD',1)");

            migrationBuilder.Sql("insert into Models values ('Make2-ModelA',2)");
            migrationBuilder.Sql("insert into Models values ('Make2-ModelB',2)");
            migrationBuilder.Sql("insert into Models values ('Make2-ModelC',2)");
            migrationBuilder.Sql("insert into Models values ('Make2-ModelD',2)");

            migrationBuilder.Sql("insert into Models values ('Make3-ModelA',3)");
            migrationBuilder.Sql("insert into Models values ('Make3-ModelB',3)");
            migrationBuilder.Sql("insert into Models values ('Make3-ModelC',3)");
            migrationBuilder.Sql("insert into Models values ('Make3-ModelD',3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from makes");
            migrationBuilder.Sql("Delete from models");
        }
    }
}
