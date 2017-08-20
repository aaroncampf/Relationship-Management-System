namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMessagefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interests", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Interests", "Message");
        }
    }
}
