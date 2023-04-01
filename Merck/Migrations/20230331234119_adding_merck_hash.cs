using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class adding_merck_hash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashFileName",
                table: "FileLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerckHash",
                table: "FileLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("5009a0b7-a02d-46f5-9455-6ea0af2d307c"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("4a770915-bd24-4e32-b018-81ae7275f256"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("1826be8c-0dd7-4c9b-ad80-d189dc4fd73c"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("f725faa8-1d44-4b95-a5b6-7570dd03b00d"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("e6fd0b3a-b219-4f9e-93ca-18ce3093f505"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("f9b5bf1a-7302-4f1e-b9d9-84d5807a0488"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("a3c65709-2767-4cf8-9425-2810f13b8b12"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("3e74ac23-fb39-4093-9e37-7a72eb988b91"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("8eb98268-18fa-45f6-a390-d12a515dd049"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("b82ae696-189d-4754-ab37-bee0c72caf50"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("75b41506-a41a-421b-839e-c9dacfe4cc9c"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("54ddd15e-c659-4cc6-a360-2193fd769d22"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("29a603ec-b389-40d7-beff-337b77b0a34a"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("66d2e65c-7531-41f3-a70c-181ef9295ea5"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("394e112b-a093-46df-8216-9cc4c4bfe812"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashFileName",
                table: "FileLog");

            migrationBuilder.DropColumn(
                name: "MerckHash",
                table: "FileLog");

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("3b1bccb6-f37c-4082-8167-d3dbeff038a0"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("a6141e8f-ff33-4b3c-82d5-c25061071efe"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("fe387ccf-43ba-40d3-9872-43ed978ab2d5"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("02451474-9536-436f-96dc-4fc08dfe6912"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("585652d4-8bb1-424a-be88-211e4eb42a8b"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("8a28ad32-2405-47da-a4df-e5f4c825c7a4"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("7e6c86c4-0ca7-4262-aa17-6a3a82ef76d6"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("972c04db-fa5f-437d-b40e-e42dada1373a"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("bee897fe-2a49-4669-955a-06f8f380f210"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("0e9b78ca-247d-4ca1-83bf-e3477a51659c"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("511e358e-82bf-4d5f-b741-7246c32bbbda"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("64741397-a606-485a-b3fd-9620be83d30e"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("be9709a8-1983-4050-9cf9-1a207fbe4ebd"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("268110db-6535-4059-9a5f-6b5b2ee48f21"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("6d4a3deb-87a2-4003-b36f-c0c3c867d4e9"));
        }
    }
}
