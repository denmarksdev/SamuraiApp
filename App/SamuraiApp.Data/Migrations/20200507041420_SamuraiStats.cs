using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class SamuraiStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
CREATE FUNCTION EarliesBattleFoughtBySamurai(@samuraiId inT)
	RETURNS CHAR(30) AS
	BEGIN
		DECLARE @ret CHAR(30);
		SELECT TOP 1 @ret = [Name]
		FROM Battles
		WHERE Battles.Id IN (SELECT  BattleId
							 FROM SamuraiBattle
							 WHERE SamuraiId = @samuraiId)
		ORDER BY StarDate
		RETURN @ret;
	END;");

			migrationBuilder.Sql(@"
CREATE VIEW SamuraiBattleStats
	AS
	SELECT Samurais.[Name],
		COUNT(SamuraiBattle.BattleId) AS NumberOfBattles,
	  	dbo.EarliesBattleFoughtBySamurai(min(Samurais.Id)) as EraliesBattles
	FROM SamuraiBattle INNER JOIN
 		 Samurais on SamuraiBattle.SamuraiId = Samurais.Id
	GROUP BY Samurais.[Name], SamuraiBattle.SamuraiId
");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP VIEW SamuraiBattlesStats");
			migrationBuilder.Sql("DROP FUNCTION EarlyBattleFoughBySamurai");
        }
    }
}
