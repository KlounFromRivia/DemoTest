namespace DemoTest.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DemoTestDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ClientId");
            DropColumn("dbo.Orders", "WorkerId");
            RenameColumn(table: "dbo.Orders", name: "Clients_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Orders", name: "Workers_Id", newName: "WorkerId");
            RenameIndex(table: "dbo.Orders", name: "IX_Clients_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Orders", name: "IX_Workers_Id", newName: "IX_WorkerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_WorkerId", newName: "IX_Workers_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_ClientId", newName: "IX_Clients_Id");
            RenameColumn(table: "dbo.Orders", name: "WorkerId", newName: "Workers_Id");
            RenameColumn(table: "dbo.Orders", name: "ClientId", newName: "Clients_Id");
            AddColumn("dbo.Orders", "WorkerId", c => c.Int());
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
        }
    }
}
