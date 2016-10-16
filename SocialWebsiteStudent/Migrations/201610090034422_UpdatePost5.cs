namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
        }
    }
}
