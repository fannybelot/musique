namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
