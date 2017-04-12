namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Content = c.String(nullable: false, maxLength: 1000),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        ReleaseDate = c.Int(nullable: false),
                        Artist = c.String(nullable: false, maxLength: 60),
                        Album = c.String(nullable: false, maxLength: 60),
                        Genre = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musics");
            DropTable("dbo.Comments");
        }
    }
}
