namespace Relationship_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProCon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProCons", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ProCons", new[] { "Contact_Id" });
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
            
            DropColumn("dbo.ProCons", "Contact_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProCons", "Contact_Id", c => c.Int());
            DropForeignKey("dbo.ProConContacts", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ProConContacts", "ProCon_Id", "dbo.ProCons");
            DropIndex("dbo.ProConContacts", new[] { "Contact_Id" });
            DropIndex("dbo.ProConContacts", new[] { "ProCon_Id" });
            DropTable("dbo.ProConContacts");
            CreateIndex("dbo.ProCons", "Contact_Id");
            AddForeignKey("dbo.ProCons", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
