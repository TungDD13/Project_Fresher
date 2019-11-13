namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostContent", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Tags", "Count", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(maxLength: 1024));
            AlterColumn("dbo.Tags", "Description", c => c.String(maxLength: 1024));
            DropColumn("dbo.Posts", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Tags", "Description", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 1024));
            DropColumn("dbo.Tags", "Count");
            DropColumn("dbo.Posts", "PostContent");
        }
    }
}
