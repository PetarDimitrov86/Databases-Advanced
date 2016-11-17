namespace _12_BillsPaymentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Owner = c.String(),
                        BankName = c.String(),
                        SWIFTCode = c.String(),
                        CardType = c.String(),
                        ExpirationMonth = c.String(),
                        ExpirationYear = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BillingDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingDetails", t => t.BillingDetail_Id)
                .Index(t => t.BillingDetail_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BillingDetail_Id", "dbo.BillingDetails");
            DropIndex("dbo.Users", new[] { "BillingDetail_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.BillingDetails");
        }
    }
}
