namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationTitle = c.String(),
                        NotificationContent = c.String(),
                        PostId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                        NotificationDateTime = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.MessageId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagPosts", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Notifications", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Notifications", "MessageId", "dbo.Messages");
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TagPosts", new[] { "TagId" });
            DropIndex("dbo.TagPosts", new[] { "PostId" });
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Notifications", new[] { "MessageId" });
            DropIndex("dbo.Notifications", new[] { "PostId" });
            DropTable("dbo.Tags");
            DropTable("dbo.TagPosts");
            DropTable("dbo.Notifications");
        }
    }
}
