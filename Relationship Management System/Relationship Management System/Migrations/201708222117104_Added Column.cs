namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsHidden");
        }
    }
}
