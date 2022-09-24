namespace InvoiceApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAppUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoice", "InvoiceCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Invoice", new[] { "InvoiceCreator_Id" });
            AddColumn("dbo.Invoice", "InvoiceCreator", c => c.String());
            DropColumn("dbo.Invoice", "InvoiceCreator_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoice", "InvoiceCreator_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Invoice", "InvoiceCreator");
            CreateIndex("dbo.Invoice", "InvoiceCreator_Id");
            AddForeignKey("dbo.Invoice", "InvoiceCreator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
