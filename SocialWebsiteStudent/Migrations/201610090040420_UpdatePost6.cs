namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post_ID", c => c.Int());
            CreateIndex("dbo.Comments", "Post_ID");
            AddForeignKey("dbo.Comments", "Post_ID", "dbo.Posts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropColumn("dbo.Comments", "Post_ID");
        }
    }
}
