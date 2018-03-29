using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LymcWeb.Data.Migrations
{
    public partial class Addroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleModelRoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleModelRoleId",
                table: "AspNetUsers",
                column: "RoleModelRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoleModel_RoleModelRoleId",
                table: "AspNetUsers",
                column: "RoleModelRoleId",
                principalTable: "RoleModel",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleModel_RoleModelRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RoleModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleModelRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleModelRoleId",
                table: "AspNetUsers");
        }
    }
}
