using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctors",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("00261b73-461b-4301-b343-e9e755385ecd"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8454), "Инфекционист" },
                    { new Guid("35ed9da3-b212-4ef9-9e0a-44811be770ec"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8446), "Акушер-гинеколог" },
                    { new Guid("3749e7e9-0255-4b76-ad60-5a9c6e4cdeea"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8483), "Эндокринолог" },
                    { new Guid("533a4457-cb20-45ee-881a-98eb43a32b54"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8480), "Стоматолог" },
                    { new Guid("57163c84-11be-4a05-9313-ea583f4a1de3"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8479), "Ревматолог" },
                    { new Guid("77f422b7-fe13-4653-8dcb-1b4ddbbe5fd5"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8477), "Педиатр" },
                    { new Guid("78dfe648-3829-48b3-9c76-d0b0987647e8"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8482), "Хирург" },
                    { new Guid("7de43cb8-b34a-4455-9cf6-b2d54f40597d"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8450), "Анестезиолог-реаниматолог" },
                    { new Guid("851e66ed-e55a-4e0f-b855-1f0bf7f16ad4"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8452), "Дерматовенеролог" },
                    { new Guid("a769f80d-9385-4a78-b189-5b565d54c82b"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8456), "Кардиолог" },
                    { new Guid("d0da12fb-2bb4-417b-b1ba-eb7d7da45ce0"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8476), "Ортопед" },
                    { new Guid("d5a52689-999c-46ae-a413-2b838b907c75"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8458), "Невролог" },
                    { new Guid("eee10541-6d2b-4afe-9ba5-175225614561"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8460), "Онколог" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("00261b73-461b-4301-b343-e9e755385ecd"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("35ed9da3-b212-4ef9-9e0a-44811be770ec"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("3749e7e9-0255-4b76-ad60-5a9c6e4cdeea"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("533a4457-cb20-45ee-881a-98eb43a32b54"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("57163c84-11be-4a05-9313-ea583f4a1de3"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("77f422b7-fe13-4653-8dcb-1b4ddbbe5fd5"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("78dfe648-3829-48b3-9c76-d0b0987647e8"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7de43cb8-b34a-4455-9cf6-b2d54f40597d"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("851e66ed-e55a-4e0f-b855-1f0bf7f16ad4"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a769f80d-9385-4a78-b189-5b565d54c82b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d0da12fb-2bb4-417b-b1ba-eb7d7da45ce0"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d5a52689-999c-46ae-a413-2b838b907c75"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("eee10541-6d2b-4afe-9ba5-175225614561"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
