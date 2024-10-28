using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("16eba5c8-c5b3-4a2f-acca-87915d3100c6"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("21201d71-00ab-434b-90e0-610a030bf852"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("29135838-af06-44da-89cd-f1a0c3187577"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4bda086d-7d07-4421-8745-42ac8a0c15d2"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6668cf41-9fdd-40d6-a1a9-9f74e3aaec32"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6e391505-d630-46e3-b023-3a61e28cf400"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7185a783-2873-4594-ae99-7027e381b1f2"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("83243d0a-504d-45f1-9efc-1568b5034c72"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a2a69975-af5f-4f9f-a4e7-05c675291d8b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("b8f2c7ee-5a13-495d-aec2-c06224ff0d68"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("bd796efb-6103-4124-97d7-1960d7d66af7"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("cf95cb57-6283-4127-ad60-018643242f07"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f74ac284-f2af-4102-a2bd-63de429588b1"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("16eba5c8-c5b3-4a2f-acca-87915d3100c6"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9121), "Кардиолог" },
                    { new Guid("21201d71-00ab-434b-90e0-610a030bf852"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9151), "Стоматолог" },
                    { new Guid("29135838-af06-44da-89cd-f1a0c3187577"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9153), "Хирург" },
                    { new Guid("4bda086d-7d07-4421-8745-42ac8a0c15d2"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9106), "Акушер-гинеколог" },
                    { new Guid("6668cf41-9fdd-40d6-a1a9-9f74e3aaec32"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9149), "Ревматолог" },
                    { new Guid("6e391505-d630-46e3-b023-3a61e28cf400"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9123), "Невролог" },
                    { new Guid("7185a783-2873-4594-ae99-7027e381b1f2"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9116), "Дерматовенеролог" },
                    { new Guid("83243d0a-504d-45f1-9efc-1568b5034c72"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9112), "Анестезиолог-реаниматолог" },
                    { new Guid("a2a69975-af5f-4f9f-a4e7-05c675291d8b"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9147), "Педиатр" },
                    { new Guid("b8f2c7ee-5a13-495d-aec2-c06224ff0d68"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9155), "Эндокринолог" },
                    { new Guid("bd796efb-6103-4124-97d7-1960d7d66af7"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9119), "Инфекционист" },
                    { new Guid("cf95cb57-6283-4127-ad60-018643242f07"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9125), "Онколог" },
                    { new Guid("f74ac284-f2af-4102-a2bd-63de429588b1"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9144), "Ортопед" }
                });
        }
    }
}
