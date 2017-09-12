namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactedProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(maxLength: 4000),
                        LastContacted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        State = c.String(maxLength: 4000),
                        Zip = c.String(maxLength: 4000),
                        Profile = c.String(maxLength: 4000),
                        IsHidden = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(maxLength: 4000),
                        Group = c.String(maxLength: 4000),
                        Title = c.String(maxLength: 4000),
                        Details = c.String(maxLength: 4000),
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
                        Title = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Message = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinimalRequredScoreForMatch = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        State = c.String(maxLength: 4000),
                        Zip = c.String(maxLength: 4000),
                        Details = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProConContacts",
                c => new
                    {
                        ProCon_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProCon_Id, t.Contact_Id })
                .ForeignKey("dbo.ProCons", t => t.ProCon_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.ProCon_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProConContacts", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ProConContacts", "ProCon_Id", "dbo.ProCons");
            DropForeignKey("dbo.PersonalDetails", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ProConContacts", new[] { "Contact_Id" });
            DropIndex("dbo.ProConContacts", new[] { "ProCon_Id" });
            DropIndex("dbo.PersonalDetails", new[] { "Contact_Id" });
            DropTable("dbo.ProConContacts");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Settings");
            DropTable("dbo.Locations");
            DropTable("dbo.Interests");
            DropTable("dbo.ProCons");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactedProfiles");
        }
    }
}
