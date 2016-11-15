namespace _04_SalesDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthTo80 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreLocations", "LocationName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
