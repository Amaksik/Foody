using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Foody.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "daily_limits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    calories = table.Column<double>(type: "double precision", nullable: false),
                    carbs = table.Column<double>(type: "double precision", nullable: false),
                    protein = table.Column<double>(type: "double precision", nullable: false),
                    fat = table.Column<double>(type: "double precision", nullable: false),
                    water = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daily_limits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "goals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    goal_weight_value = table.Column<double>(type: "double precision", nullable: false),
                    current_weight_value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "measurements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measurements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    chat_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_daily_limits_id",
                        column: x => x.id,
                        principalTable: "daily_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_goals_id",
                        column: x => x.id,
                        principalTable: "goals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_measurements_id",
                        column: x => x.id,
                        principalTable: "measurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "food_intakes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    calories = table.Column<double>(type: "double precision", nullable: false),
                    carbs = table.Column<double>(type: "double precision", nullable: true),
                    fat = table.Column<double>(type: "double precision", nullable: true),
                    protein = table.Column<double>(type: "double precision", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_intakes", x => x.id);
                    table.ForeignKey(
                        name: "FK_food_intakes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_intakes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_intakes", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_intakes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_food_intakes_user_id",
                table: "food_intakes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_water_intakes_user_id",
                table: "water_intakes",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_intakes");

            migrationBuilder.DropTable(
                name: "water_intakes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "daily_limits");

            migrationBuilder.DropTable(
                name: "goals");

            migrationBuilder.DropTable(
                name: "measurements");
        }
    }
}
