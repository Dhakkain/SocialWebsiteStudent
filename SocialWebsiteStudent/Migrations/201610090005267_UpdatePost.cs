namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            AddColumn("dbo.Posts", "Comment_ID", c => c.Int());
            CreateIndex("dbo.Posts", "Comment_ID");
            AddForeignKey("dbo.Posts", "Comment_ID", "dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Comment_ID", "dbo.Comments");
            DropIndex("dbo.Posts", new[] { "Comment_ID" });
            DropColumn("dbo.Posts", "Comment_ID");
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "ID", cascadeDelete: true);
        }
    }
}
