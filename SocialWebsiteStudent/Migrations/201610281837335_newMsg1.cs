namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMsg1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ToUserId", c => c.String());
            DropColumn("dbo.Messages", "ToUserName");
            DropColumn("dbo.Messages", "FromUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUserName", c => c.String());
            AddColumn("dbo.Messages", "ToUserName", c => c.String());
            DropColumn("dbo.Messages", "ToUserId");
        }
    }
}
