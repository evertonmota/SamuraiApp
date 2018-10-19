using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class relationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropColumn(
                name: "BatteleId",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "BattleId",
                table: "SamuraiBattle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SamuariId", "BattleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "BattleId",
                table: "SamuraiBattle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BatteleId",
                table: "SamuraiBattle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SamuariId", "BatteleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
