namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactedProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactedProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactedProfiles");
        }
    }
}
