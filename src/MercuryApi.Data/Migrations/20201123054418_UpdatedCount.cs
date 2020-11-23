using Microsoft.EntityFrameworkCore.Migrations;

namespace MercuryApi.Data.Migrations
{
    public partial class UpdatedCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpdatedTimesCount",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedTimesCount",
                table: "Sessions");
        }
    }
}
