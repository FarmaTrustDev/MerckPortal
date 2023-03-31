using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class FileLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tempered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileLog", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileLog");

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("246bf432-6af5-476f-acb9-13ef27122428"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("f2119fc6-19c0-4514-a6f2-8a9c02b602c9"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("f7b2770a-4455-40fc-9638-c551dd2ea419"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("f7f765a1-45dd-4ec7-8824-49283df223ec"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("6216075c-b0cb-44b7-babf-1e844dff2d8f"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("46e964b1-a387-425f-9384-d49f8e976f64"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("bcb62726-a20c-43ed-b5bc-e324b64cced1"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("8fe10ccc-9194-4a91-84c2-804ed9f5fc27"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("22c0961e-9842-497d-b128-e56616341e11"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("242171bd-f56e-46ae-8966-7bd72d92b54d"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("21cb9f27-5583-411c-b941-de9dc3c51028"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("841a0b25-792d-4bfa-b308-31fbdedf3366"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("c6fda45c-9690-4a43-baeb-ea2eddb9f58c"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("67abc9e8-cb61-4fdd-834b-a0a1f919294c"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("c82597a3-5509-4f62-872c-76e9ef350fe4"));
        }
    }
}
