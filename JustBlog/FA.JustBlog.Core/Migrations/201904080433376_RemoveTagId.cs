namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTagId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags");
            DropIndex("dbo.PostTagMap", new[] { "TagId" });
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.PostTagMap");
            AlterColumn("dbo.PostTagMap", "TagId", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Tags", "Name");
            AddPrimaryKey("dbo.PostTagMap", new[] { "PostId", "TagId" });
            CreateIndex("dbo.PostTagMap", "TagId");
            AddForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags", "Name", cascadeDelete: true);
            DropColumn("dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags");
            DropIndex("dbo.PostTagMap", new[] { "TagId" });
            DropPrimaryKey("dbo.PostTagMap");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.PostTagMap", "TagId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PostTagMap", new[] { "PostId", "TagId" });
            AddPrimaryKey("dbo.Tags", "Id");
            CreateIndex("dbo.PostTagMap", "TagId");
            AddForeignKey("dbo.PostTagMap", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
