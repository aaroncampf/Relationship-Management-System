namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProCons", "Title", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProCons", "Title");
        }
    }
}
