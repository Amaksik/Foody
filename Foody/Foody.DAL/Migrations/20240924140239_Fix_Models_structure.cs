using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Foody.DAL.Migrations
{
    public partial class Fix_Models_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_daily_limits_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_goals_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_measurements_id",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "measurements",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "height",
                table: "measurements",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "goal_weight_value",
                table: "goals",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "current_weight_value",
                table: "goals",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "water",
                table: "daily_limits",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "protein",
                table: "daily_limits",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "fat",
                table: "daily_limits",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "carbs",
                table: "daily_limits",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "calories",
                table: "daily_limits",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_measurements_user_id",
                table: "measurements",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goals_user_id",
                table: "goals",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_daily_limits_user_id",
                table: "daily_limits",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_daily_limits_users_user_id",
                table: "daily_limits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goals_users_user_id",
                table: "goals",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_measurements_users_user_id",
                table: "measurements",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_daily_limits_users_user_id",
                table: "daily_limits");

            migrationBuilder.DropForeignKey(
                name: "FK_goals_users_user_id",
                table: "goals");

            migrationBuilder.DropForeignKey(
                name: "FK_measurements_users_user_id",
                table: "measurements");

            migrationBuilder.DropIndex(
                name: "IX_measurements_user_id",
                table: "measurements");

            migrationBuilder.DropIndex(
                name: "IX_goals_user_id",
                table: "goals");

            migrationBuilder.DropIndex(
                name: "IX_daily_limits_user_id",
                table: "daily_limits");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<double>(
                name: "weight",
                table: "measurements",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "height",
                table: "measurements",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "goal_weight_value",
                table: "goals",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "current_weight_value",
                table: "goals",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "water",
                table: "daily_limits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "protein",
                table: "daily_limits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "fat",
                table: "daily_limits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "carbs",
                table: "daily_limits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "calories",
                table: "daily_limits",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_daily_limits_id",
                table: "users",
                column: "id",
                principalTable: "daily_limits",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_goals_id",
                table: "users",
                column: "id",
                principalTable: "goals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_measurements_id",
                table: "users",
                column: "id",
                principalTable: "measurements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
