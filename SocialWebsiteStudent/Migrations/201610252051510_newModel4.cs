namespace SocialWebsiteStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "ToUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ToUser", c => c.String());
        }
    }
}
