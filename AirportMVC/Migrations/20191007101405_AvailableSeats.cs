using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportMVC.Migrations
{
    public partial class AvailableSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ToLocation",
                table: "Flight",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromLocation",
                table: "Flight",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Flight",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Flight");

            migrationBuilder.AlterColumn<string>(
                name: "ToLocation",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FromLocation",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
