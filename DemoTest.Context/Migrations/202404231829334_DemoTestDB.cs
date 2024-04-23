namespace DemoTest.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DemoTestDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        WorkerId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateOrder = c.DateTime(nullable: false),
                        ModelEquipment = c.String(nullable: false),
                        TypeEquipmentId = c.Int(nullable: false),
                        ReasonDefect = c.String(nullable: false),
                        ClientId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        WorkerId = c.Int(),
                        Zapchasty = c.String(),
                        Clients_Id = c.Int(nullable: false),
                        Workers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Clients_Id)
                .ForeignKey("dbo.Users", t => t.Workers_Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.TypeEquipments", t => t.TypeEquipmentId, cascadeDelete: true)
                .Index(t => t.TypeEquipmentId)
                .Index(t => t.StatusId)
                .Index(t => t.Clients_Id)
                .Index(t => t.Workers_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.Orders", "TypeEquipmentId", "dbo.TypeEquipments");
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Comments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "Workers_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Clients_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "Workers_Id" });
            DropIndex("dbo.Orders", new[] { "Clients_Id" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Orders", new[] { "TypeEquipmentId" });
            DropIndex("dbo.Comments", new[] { "OrderId" });
            DropIndex("dbo.Comments", new[] { "WorkerId" });
            DropTable("dbo.TypeEquipments");
            DropTable("dbo.Status");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Comments");
        }
    }
}
