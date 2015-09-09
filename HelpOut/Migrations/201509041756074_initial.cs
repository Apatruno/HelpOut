namespace HelpOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "UserProfileDTO_Id", "dbo.UserProfileDTOes");
            DropIndex("dbo.Events", new[] { "UserProfileDTO_Id" });
            DropIndex("dbo.FilePaths", new[] { "EventId" });
            DropColumn("dbo.Events", "UserProfileDTO_Id");
            DropTable("dbo.FilePaths");
            DropTable("dbo.UserProfileDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfileDTOes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            AddColumn("dbo.Events", "UserProfileDTO_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FilePaths", "EventId");
            CreateIndex("dbo.Events", "UserProfileDTO_Id");
            AddForeignKey("dbo.Events", "UserProfileDTO_Id", "dbo.UserProfileDTOes", "Id");
            AddForeignKey("dbo.FilePaths", "EventId", "dbo.Events", "EventID", cascadeDelete: true);
        }
    }
}
