namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ttest2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Interests", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Interests", "Name", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
