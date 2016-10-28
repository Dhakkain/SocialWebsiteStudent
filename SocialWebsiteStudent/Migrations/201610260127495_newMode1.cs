namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMode1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "MessageTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageTitle", c => c.String());
        }
    }
}
