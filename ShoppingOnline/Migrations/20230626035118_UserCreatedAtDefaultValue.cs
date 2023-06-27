using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingOnline.Migrations
{
    /// <inheritdoc />
    public partial class UserCreatedAtDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 21, 51, 18, 85, DateTimeKind.Local).AddTicks(4543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 21, 51, 18, 85, DateTimeKind.Local).AddTicks(4543));
        }
    }
}
