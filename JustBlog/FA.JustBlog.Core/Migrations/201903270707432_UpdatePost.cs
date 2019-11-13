namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ViewCount", c => c.Int());
            AlterColumn("dbo.Posts", "RateCount", c => c.Int());
            AlterColumn("dbo.Posts", "TotalRate", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "TotalRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "RateCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "ViewCount", c => c.Int(nullable: false));
        }
    }
}
