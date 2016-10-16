namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            RenameColumn(table: "dbo.Comments", name: "Post_ID", newName: "PostId");
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: true));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_ID");
            CreateIndex("dbo.Comments", "Post_ID");
            AddForeignKey("dbo.Comments", "Post_ID", "dbo.Posts", "ID");
        }
    }
}
