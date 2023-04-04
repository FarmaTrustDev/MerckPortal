using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class Add_Device_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "FileLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("f466f79d-b6dc-459c-aadd-69dc586c7767"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("d5068abb-f3da-4356-8036-e9cd92fc16d4"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("04978825-b197-4dde-b9f4-6966f743fb89"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("61815456-9062-40d4-ac7f-f95b2a9570d9"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("6f3c46d8-8bd7-41e0-9286-a64b301455c6"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("1d734ead-5c28-488d-9f4d-6d8827bbe42f"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("638d59a9-98d0-4b86-8b1d-722e988aa824"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("67ed9391-781c-461f-a95a-75e902672e9e"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("8e43999a-822c-4e78-98d9-0274e5c7c516"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("afd3992c-699d-457b-bf34-49a5bdb90529"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("4d9a570c-0ea3-4fd7-9ee1-18e678378191"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("065c0259-d247-42e5-8319-583f1eb1a8a0"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("53d3b57e-227b-49b4-8f90-4573e24ad96a"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("017dee79-261e-495f-8b3e-4b6c48a7e082"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("963e52f7-7252-4d0d-bb37-ac0469ac50be"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "FileLog");

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("ceada6c3-d567-405c-a483-3cbbf6807ef3"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("6e3631e0-20f1-48a9-a5d4-5112c99ff068"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("c32c3d53-ce99-49a3-9841-a45e94aac41a"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("7ff16e39-d015-4dee-8a8e-4342480b7e11"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("1b237ddb-a651-43f9-84c2-d37b57e95c66"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("0086a073-aa51-46cc-a776-5abf1858a5a3"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("0f3adbdf-5a60-4cea-bb50-729d568b855c"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("f9012523-58fd-402b-9989-ebd41a7db320"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("3ea00894-9c11-4afb-9b2f-31720992d69c"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("28e89211-50aa-4a94-8917-ac4cfd33b40f"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("94b46501-ab7d-4e62-a008-1b3c572fcf4a"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("afabf00e-0bb0-4232-8b8f-8340af83913f"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("dacdedec-4fde-47b3-8ce1-d399012ab39d"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("65cc86ca-830c-443b-968e-83545f542564"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("d90021cc-e1a9-4d93-a7b9-093db9c1ac4b"));
        }
    }
}
