namespace _04_SalesDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class JustTestingSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 80));
        }
    }
}