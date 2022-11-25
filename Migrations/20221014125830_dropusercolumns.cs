using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAMCLIENTAPI.Migrations
{
    public partial class dropusercolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "users",
                newName: "refreshToken");

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "refreshToken",
                table: "users",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
