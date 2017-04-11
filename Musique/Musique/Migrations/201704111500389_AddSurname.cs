namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
