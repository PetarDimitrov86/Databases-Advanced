namespace _04_SalesDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLenghtLocationNameChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
