using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("91577f02-7653-450f-b9ad-7ec712ef38a5"), null, "Personal", 10 },
                    { new Guid("91577f02-7653-450f-b9ad-7ec712ef38d4"), null, "Actividades", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("91577f02-7653-450f-b9ad-7ec712ef38c1"), new Guid("91577f02-7653-450f-b9ad-7ec712ef38a5"), "Descripcion de la tarea 1", new DateTime(2024, 7, 17, 17, 57, 1, 428, DateTimeKind.Local).AddTicks(9669), 0, "Tarea 2" },
                    { new Guid("91577f02-7653-450f-b9ad-7ec712ef38c5"), new Guid("91577f02-7653-450f-b9ad-7ec712ef38d4"), "Descripcion de la tarea 1", new DateTime(2024, 7, 17, 17, 57, 1, 428, DateTimeKind.Local).AddTicks(9656), 1, "Tarea 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("91577f02-7653-450f-b9ad-7ec712ef38c1"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("91577f02-7653-450f-b9ad-7ec712ef38c5"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("91577f02-7653-450f-b9ad-7ec712ef38a5"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("91577f02-7653-450f-b9ad-7ec712ef38d4"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
