using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatnDoctorAndCommentClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Consultations_ConsultationId",
                table: "Comments");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultationId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0f0af2f1-56ac-48ee-b712-839530c90d77"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(148), "Кардиолог" },
                    { new Guid("19e7995b-cabc-430a-9ccf-17b6c7465875"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(126), "Дерматовенеролог" },
                    { new Guid("219efdb9-f5fe-4247-93b9-ca41f3244d03"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(149), "Невролог" },
                    { new Guid("38ec8cdf-db21-48e9-8a6b-834ef19137e8"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(199), "Ревматолог" },
                    { new Guid("453c7b23-c164-4bef-9d91-26a025cfa499"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(146), "Инфекционист" },
                    { new Guid("4d4dc5e0-4bd6-43d6-999a-ed5c7682cf45"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(153), "Ортопед" },
                    { new Guid("61977184-c22e-47dd-a9de-035521a0b015"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(118), "Акушер-гинеколог" },
                    { new Guid("622741bd-4652-4c45-858e-f8fe32ff0a82"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(207), "Эндокринолог" },
                    { new Guid("7b6e01ae-6b49-48e9-a5b6-706f79c2689c"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(124), "Анестезиолог-реаниматолог" },
                    { new Guid("7c77a89a-1a41-4256-bd72-51d91cfbca0b"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(200), "Стоматолог" },
                    { new Guid("9150701f-da80-4bed-88e0-83fb97a7a5ec"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(205), "Хирург" },
                    { new Guid("bc6437a4-6f97-4915-a000-315683620a37"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(155), "Педиатр" },
                    { new Guid("e0f6ebaa-7d21-41e9-833a-8ecc138c08e0"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(151), "Онколог" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Consultations_ConsultationId",
                table: "Comments",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Consultations_ConsultationId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("0f0af2f1-56ac-48ee-b712-839530c90d77"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("19e7995b-cabc-430a-9ccf-17b6c7465875"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("219efdb9-f5fe-4247-93b9-ca41f3244d03"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("38ec8cdf-db21-48e9-8a6b-834ef19137e8"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("453c7b23-c164-4bef-9d91-26a025cfa499"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4d4dc5e0-4bd6-43d6-999a-ed5c7682cf45"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("61977184-c22e-47dd-a9de-035521a0b015"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("622741bd-4652-4c45-858e-f8fe32ff0a82"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7b6e01ae-6b49-48e9-a5b6-706f79c2689c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7c77a89a-1a41-4256-bd72-51d91cfbca0b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("9150701f-da80-4bed-88e0-83fb97a7a5ec"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("bc6437a4-6f97-4915-a000-315683620a37"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("e0f6ebaa-7d21-41e9-833a-8ecc138c08e0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultationId",
                table: "Comments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Consultations_ConsultationId",
                table: "Comments",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id");
        }
    }
}
