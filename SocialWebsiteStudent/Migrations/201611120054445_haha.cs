namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class haha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromUserName_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "ToUserName_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "FromUserName_Id");
            CreateIndex("dbo.Messages", "ToUserName_Id");
            AddForeignKey("dbo.Messages", "FromUserName_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "ToUserName_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "ToUserName");
            DropColumn("dbo.Messages", "FromUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUserName", c => c.String());
            AddColumn("dbo.Messages", "ToUserName", c => c.String());
            DropForeignKey("dbo.Messages", "ToUserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "FromUserName_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ToUserName_Id" });
            DropIndex("dbo.Messages", new[] { "FromUserName_Id" });
            DropColumn("dbo.Messages", "ToUserName_Id");
            DropColumn("dbo.Messages", "FromUserName_Id");
        }
    }
}
