namespace EF_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditCards");
        }
    }
}
