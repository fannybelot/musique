namespace Musique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201704101220574_Comments1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Comments", "Title", c => c.String());
        }
    }
}
