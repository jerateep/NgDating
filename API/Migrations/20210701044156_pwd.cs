using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class pwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUser");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "AppUser",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AppUser",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AppUser");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
