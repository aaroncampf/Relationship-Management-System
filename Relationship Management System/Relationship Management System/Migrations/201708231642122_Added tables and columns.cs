namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtablesandcolumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        State = c.String(maxLength: 4000),
                        Zip = c.String(maxLength: 4000),
                        Details = c.String(maxLength: 4000),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SocialLinks", "Address", c => c.String(maxLength: 4000));
            AddColumn("dbo.SocialLinks", "City", c => c.String(maxLength: 4000));
            AddColumn("dbo.SocialLinks", "State", c => c.String(maxLength: 4000));
            AddColumn("dbo.SocialLinks", "Zip", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialLinks", "Zip");
            DropColumn("dbo.SocialLinks", "State");
            DropColumn("dbo.SocialLinks", "City");
            DropColumn("dbo.SocialLinks", "Address");
            DropTable("dbo.Locations");
        }
    }
}
