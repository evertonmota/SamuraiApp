using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battles_BattleID",
                table: "Samurais");

            migrationBuilder.RenameColumn(
                name: "BattleID",
                table: "Samurais",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais",
                newName: "IX_Samurais_BattleId");

            migrationBuilder.AlterColumn<int>(
                name: "BattleId",
                table: "Samurais",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "SamuraiBattle",
                columns: table => new
                {
                    SamuariId = table.Column<int>(nullable: false),
                    SamuraiId = table.Column<int>(nullable: true),
                    BatteleId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiBattle", x => new { x.SamuariId, x.BatteleId });
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentity_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battles_BattleId",
                table: "Samurais",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battles_BattleId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "SamuraiBattle");

            migrationBuilder.DropTable(
                name: "SecretIdentity");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "Samurais",
                newName: "BattleID");

            migrationBuilder.RenameIndex(
                name: "IX_Samurais_BattleId",
                table: "Samurais",
                newName: "IX_Samurais_BattleID");

            migrationBuilder.AlterColumn<int>(
                name: "BattleID",
                table: "Samurais",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battles_BattleID",
                table: "Samurais",
                column: "BattleID",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
