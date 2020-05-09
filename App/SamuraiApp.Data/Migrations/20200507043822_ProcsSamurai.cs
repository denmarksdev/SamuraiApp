using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class ProcsSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
CREATE PROC SamuraisWhoSaidWord
	@text varchar(20)
	AS
	SELECT Samurais.Id, Samurais.[Name], Samurais.ClanId
	FROM Samurais INNER JOIN	
		 Quotes on Samurais.Id = Quotes.SamuraiId	
	WHERE (Quotes.Text like '%' + @text + '%')
");

            migrationBuilder.Sql(@"
CREATE PROC DeleteQuotesForSamurai
	@samuraiId int
	AS
	DELETE FROM Quotes 
	WHERE Quotes.SamuraiId = @samuraiId;
");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC SamuraisWhoSaidWord");
            migrationBuilder.Sql("DROP PROC DeleteQuotesForSamurai");
        }
    }
}
