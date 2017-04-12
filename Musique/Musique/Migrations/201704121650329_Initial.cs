namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        MusicId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Musics", t => t.MusicId, cascadeDelete: true)
                .Index(t => t.MusicId);
            
            AddColumn("dbo.Comments", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "MusicId", "dbo.Musics");
            DropIndex("dbo.Orders", new[] { "MusicId" });
            DropColumn("dbo.Comments", "UserName");
            DropTable("dbo.Orders");
        }
    }
}
