namespace InvoiceApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceProduct", "InvoiceId", "dbo.Invoice");
            DropPrimaryKey("dbo.Invoice");
            AlterColumn("dbo.Invoice", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Invoice", "InvoiceNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Invoice", "Id");
            AddForeignKey("dbo.InvoiceProduct", "InvoiceId", "dbo.Invoice", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceProduct", "InvoiceId", "dbo.Invoice");
            DropPrimaryKey("dbo.Invoice");
            AlterColumn("dbo.Invoice", "InvoiceNumber", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Invoice", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Invoice", "Id");
            AddForeignKey("dbo.InvoiceProduct", "InvoiceId", "dbo.Invoice", "Id", cascadeDelete: true);
        }
    }
}
