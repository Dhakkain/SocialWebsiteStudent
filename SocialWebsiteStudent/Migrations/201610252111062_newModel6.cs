namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ToUser", c => c.String());
            AddColumn("dbo.Messages", "FromUser", c => c.String());
            DropColumn("dbo.Messages", "ToUserId");
            DropColumn("dbo.Messages", "FromUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "ToUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "FromUser");
            DropColumn("dbo.Messages", "ToUser");
        }
    }
}
