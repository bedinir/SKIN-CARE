namespace SKIN_CARE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountDatelindje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Datelindja", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Datelindja");
        }
    }
}
