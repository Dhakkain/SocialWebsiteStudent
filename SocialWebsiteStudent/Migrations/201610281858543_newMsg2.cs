namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMsg2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ToUserName", c => c.String());
            AddColumn("dbo.Messages", "FromUserName", c => c.String());
            DropColumn("dbo.Messages", "ToUserId");
            DropColumn("dbo.Messages", "FromUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUserId", c => c.String());
            AddColumn("dbo.Messages", "ToUserId", c => c.String());
            DropColumn("dbo.Messages", "FromUserName");
            DropColumn("dbo.Messages", "ToUserName");
        }
    }
}
