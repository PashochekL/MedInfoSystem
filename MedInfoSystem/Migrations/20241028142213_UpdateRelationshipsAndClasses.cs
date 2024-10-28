using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipsAndClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("231f948e-c491-4c1c-9d90-35b6722cd1fa"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("38230544-6ef4-4b2a-ac5c-f98c407ab379"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4f173283-0b08-4306-9998-98dcce5a2853"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("69a019c1-f95a-4a6e-a3b2-cbb2ee38cb1f"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("76a72664-7d5c-46be-952c-a68a58459a9c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("93715d44-3a0c-4992-8e15-0edae42cad07"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("ac89ac17-6986-46bb-a697-f1af6892910c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("ad87a579-55e5-455e-b020-0845ddf652e6"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("b08d8f3d-555f-425c-b211-efa853166dba"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("b5492ad0-c59c-4e47-96b2-cf5c5ee927ba"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d73f73e1-1e7b-4e12-b662-0ff2218a76fb"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d95ddca3-feb5-4d69-8019-f9d3529fa0cb"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f975ae6f-aa70-4014-b190-b616f99ec524"));

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0ef08c0f-2fb6-4421-bc5c-1b04e440d493"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3980), "Инфекционист" },
                    { new Guid("1c3ec727-2086-45fd-a1b1-8703e2513f3b"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4003), "Стоматолог" },
                    { new Guid("3978d566-0b3d-41c9-a7d3-e66b45e4ee78"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3972), "Акушер-гинеколог" },
                    { new Guid("5afc931c-0e53-49f1-a557-e93014e1d9fd"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3978), "Дерматовенеролог" },
                    { new Guid("60414cd9-d659-4179-9927-dcdb3a52f751"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3982), "Кардиолог" },
                    { new Guid("830feb82-62fc-4b04-a14a-6e74ab554a63"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3985), "Онколог" },
                    { new Guid("8c000e9f-f950-47e7-aa00-e90c05d4167e"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4007), "Эндокринолог" },
                    { new Guid("a3aa605c-6cb8-4ac7-bf27-825895c09d76"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3975), "Анестезиолог-реаниматолог" },
                    { new Guid("a3fa2b54-e5d4-481f-aa6e-579606f45de5"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4002), "Ревматолог" },
                    { new Guid("b8052338-3bc9-4cb4-8bec-548e17bf6a1b"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4005), "Хирург" },
                    { new Guid("c5da51ef-a960-49bd-b2b1-fe8cbb397487"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(4000), "Педиатр" },
                    { new Guid("e58f0b4e-7ecb-4c21-9eb3-743df55b97e7"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3983), "Невролог" },
                    { new Guid("f6792a9d-c5ba-459d-b4c8-192664abdcac"), new DateTime(2024, 10, 28, 14, 22, 12, 853, DateTimeKind.Utc).AddTicks(3999), "Ортопед" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("0ef08c0f-2fb6-4421-bc5c-1b04e440d493"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("1c3ec727-2086-45fd-a1b1-8703e2513f3b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("3978d566-0b3d-41c9-a7d3-e66b45e4ee78"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("5afc931c-0e53-49f1-a557-e93014e1d9fd"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("60414cd9-d659-4179-9927-dcdb3a52f751"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("830feb82-62fc-4b04-a14a-6e74ab554a63"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("8c000e9f-f950-47e7-aa00-e90c05d4167e"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a3aa605c-6cb8-4ac7-bf27-825895c09d76"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a3fa2b54-e5d4-481f-aa6e-579606f45de5"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("b8052338-3bc9-4cb4-8bec-548e17bf6a1b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c5da51ef-a960-49bd-b2b1-fe8cbb397487"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("e58f0b4e-7ecb-4c21-9eb3-743df55b97e7"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f6792a9d-c5ba-459d-b4c8-192664abdcac"));

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("231f948e-c491-4c1c-9d90-35b6722cd1fa"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3276), "Ортопед" },
                    { new Guid("38230544-6ef4-4b2a-ac5c-f98c407ab379"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3251), "Анестезиолог-реаниматолог" },
                    { new Guid("4f173283-0b08-4306-9998-98dcce5a2853"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3277), "Педиатр" },
                    { new Guid("69a019c1-f95a-4a6e-a3b2-cbb2ee38cb1f"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3284), "Эндокринолог" },
                    { new Guid("76a72664-7d5c-46be-952c-a68a58459a9c"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3253), "Дерматовенеролог" },
                    { new Guid("93715d44-3a0c-4992-8e15-0edae42cad07"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3257), "Кардиолог" },
                    { new Guid("ac89ac17-6986-46bb-a697-f1af6892910c"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3255), "Инфекционист" },
                    { new Guid("ad87a579-55e5-455e-b020-0845ddf652e6"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3281), "Стоматолог" },
                    { new Guid("b08d8f3d-555f-425c-b211-efa853166dba"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3273), "Невролог" },
                    { new Guid("b5492ad0-c59c-4e47-96b2-cf5c5ee927ba"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3282), "Хирург" },
                    { new Guid("d73f73e1-1e7b-4e12-b662-0ff2218a76fb"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3279), "Ревматолог" },
                    { new Guid("d95ddca3-feb5-4d69-8019-f9d3529fa0cb"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3274), "Онколог" },
                    { new Guid("f975ae6f-aa70-4014-b190-b616f99ec524"), new DateTime(2024, 10, 28, 12, 57, 4, 13, DateTimeKind.Utc).AddTicks(3246), "Акушер-гинеколог" }
                });
        }
    }
}
