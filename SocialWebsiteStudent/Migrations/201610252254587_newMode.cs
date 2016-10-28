namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMode : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "ToUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ToUserId", c => c.String());
        }
    }
}
