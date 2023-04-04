using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class Complete_Migraion_CreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedOn",
                table: "FileLog",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("757009ee-36c9-4391-85de-f45a2ce87703"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("0e6c4d76-3ae2-4247-a644-4799b5f3e3b4"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("bc338801-b672-42a9-92f9-3eac3985779e"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("8eaebd0f-1521-4a6d-87e3-295d49c52ac5"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("8bd20297-28d9-4892-aed3-dd9e2e101c79"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("ab811d1c-c49a-4bdd-a727-b7b19f9d23df"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("a28e0f1b-c895-419f-95b5-c5b45695d192"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("41ed8302-cd62-4b24-a2b0-2b29ff3722a7"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("9be4f432-6229-4eee-9779-83511cdc20b5"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("be62c816-b7f3-4f3c-a7f1-3ba1a84ada60"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("a83a4ffd-474a-4803-ab57-5baafacc6f9f"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("24d67c42-d107-4e7a-abd2-d09bd81a5593"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("6e6a7c40-e437-40e0-96d5-5d379bc63cd5"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("449f3a8e-1783-43fa-8f83-11d531280880"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("dcc5f2f2-6891-4ff0-b87f-811ef03e469d"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FileLog");

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("bfa8ae70-c69f-4ab8-b3ff-a8ecca801405"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("489418c9-45df-4f53-8416-22397f14f582"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("20e83165-4a6a-4fb3-88f2-5978b93d2fee"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("cf46d1db-5d18-4c02-8b90-1108c0d23c7f"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("74a05498-2ac3-4b70-b198-f3765f955e60"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("18d20407-49ee-4359-b44f-362d6441acbd"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("946e0451-915b-472a-b068-9ed508830e19"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("f2e708b6-3e3d-4c51-9fb3-27757af8ccf3"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("c769e31e-1cb3-463c-bcc6-1b7f3c882ec3"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("7aa7fabf-9a1d-40bd-b038-83f09ae3aaa2"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("e6a4c439-f71e-42d3-a0e3-be35a7819e93"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("b3ee342c-4e9f-44fa-942a-dc28e33ba236"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("de0f94e3-fa3d-40f4-9af6-8bfc90154c7e"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("45cebccb-5621-4f47-be02-3765c25b8dfc"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("f2506e38-fab3-4330-abfa-457e4c27338d"));
        }
    }
}
