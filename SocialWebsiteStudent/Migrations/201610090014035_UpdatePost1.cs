namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Comment_ID", "dbo.Comments");
            DropIndex("dbo.Posts", new[] { "Comment_ID" });
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "ID", cascadeDelete: true);
            DropColumn("dbo.Posts", "Comment_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Comment_ID", c => c.Int());
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            CreateIndex("dbo.Posts", "Comment_ID");
            AddForeignKey("dbo.Posts", "Comment_ID", "dbo.Comments", "ID");
        }
    }
}
