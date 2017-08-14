namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookBases", "test", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookBases", "test");
        }
    }
}
