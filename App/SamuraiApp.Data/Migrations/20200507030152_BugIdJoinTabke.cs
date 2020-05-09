using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class BugIdJoinTabke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropColumn(
                name: "SumaraiId",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SamuraiBattle",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SamuraiId", "BattleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SamuraiBattle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SumaraiId",
                table: "SamuraiBattle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "SumaraiId", "BattleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
