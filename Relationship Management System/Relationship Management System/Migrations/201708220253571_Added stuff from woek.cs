namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedstufffromwoek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Profile = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Group = c.String(),
                        Title = c.String(),
                        Details = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.ProCons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContactedProfiles", "LastContacted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProCons", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.PersonalDetails", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ProCons", new[] { "Contact_Id" });
            DropIndex("dbo.PersonalDetails", new[] { "Contact_Id" });
            DropColumn("dbo.ContactedProfiles", "LastContacted");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.ProCons");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.Contacts");
        }
    }
}
