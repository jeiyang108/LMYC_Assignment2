using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LymcWeb.Data.Migrations
{
    public partial class updatedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "RoleModel");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoleModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleModel");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "RoleModel",
                nullable: true);
        }
    }
}
