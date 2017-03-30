namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMusic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musics", "ReleaseDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musics", "ReleaseDate", c => c.Int(nullable: false));
        }
    }
}
