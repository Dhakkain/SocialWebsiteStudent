namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class msgAppAS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "FromUserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ToUserName_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "FromUserName_Id" });
            DropIndex("dbo.Messages", new[] { "ToUserName_Id" });
            AddColumn("dbo.Messages", "ToUserName", c => c.String());
            AddColumn("dbo.Messages", "FromUserName", c => c.String());
            DropColumn("dbo.Messages", "FromUserName_Id");
            DropColumn("dbo.Messages", "ToUserName_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ToUserName_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "FromUserName_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Messages", "FromUserName");
            DropColumn("dbo.Messages", "ToUserName");
            CreateIndex("dbo.Messages", "ToUserName_Id");
            CreateIndex("dbo.Messages", "FromUserName_Id");
            AddForeignKey("dbo.Messages", "ToUserName_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "FromUserName_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
