namespace HelpOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "State", c => c.String(maxLength: 2));
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "Location", c => c.String(maxLength: 150));
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: true));
            DropColumn("dbo.Events", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Country", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Location", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AlterColumn("dbo.Events", "State", c => c.String(maxLength: 20));
        }
    }
}
