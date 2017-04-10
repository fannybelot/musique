namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MusicId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    Title = c.String(nullable: false, maxLength: 60),
                    Content = c.String(nullable: false, maxLength: 60),
                    Rating = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
