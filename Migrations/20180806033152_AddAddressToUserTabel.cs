using Microsoft.EntityFrameworkCore.Migrations;

namespace dockermysql.Migrations
{
    public partial class AddAddressToUserTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "user");
        }
    }
}
