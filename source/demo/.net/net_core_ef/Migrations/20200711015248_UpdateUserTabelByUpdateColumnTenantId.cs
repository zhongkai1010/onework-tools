using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace net_core_ef.Migrations
{
    public partial class UpdateUserTabelByUpdateColumnTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "Tenant",
                table: "Users",
                type: "char(36)",
                nullable: true);
        }
    }
}
