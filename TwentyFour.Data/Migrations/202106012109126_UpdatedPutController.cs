namespace TwentyFour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPutController : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "CommentId");
            DropColumn("dbo.Post", "LikeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "LikeId", c => c.Int(nullable: false));
            AddColumn("dbo.Post", "CommentId", c => c.Int(nullable: false));
        }
    }
}
