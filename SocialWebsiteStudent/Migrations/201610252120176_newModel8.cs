namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ToUserId", c => c.String());
            AddColumn("dbo.Messages", "ToUserName", c => c.String());
            AddColumn("dbo.Messages", "FromUserId", c => c.String());
            AddColumn("dbo.Messages", "FromUserName", c => c.String());
            DropColumn("dbo.Messages", "ToUser");
            DropColumn("dbo.Messages", "FromUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUser", c => c.String());
            AddColumn("dbo.Messages", "ToUser", c => c.String());
            DropColumn("dbo.Messages", "FromUserName");
            DropColumn("dbo.Messages", "FromUserId");
            DropColumn("dbo.Messages", "ToUserName");
            DropColumn("dbo.Messages", "ToUserId");
        }
    }
}
