namespace EnergyConsumption.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sample : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Devices", name: "Home_Id1", newName: "HomeID");
            RenameColumn(table: "dbo.Homes", name: "ApplicationUser_Id1", newName: "ApplicationUserID");
            RenameIndex(table: "dbo.Devices", name: "IX_Home_Id1", newName: "IX_HomeID");
            RenameIndex(table: "dbo.Homes", name: "IX_ApplicationUser_Id1", newName: "IX_ApplicationUserID");
            DropColumn("dbo.Devices", "Home_Id");
            DropColumn("dbo.Homes", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Homes", "ApplicationUser_Id", c => c.String());
            AddColumn("dbo.Devices", "Home_Id", c => c.Int());
            RenameIndex(table: "dbo.Homes", name: "IX_ApplicationUserID", newName: "IX_ApplicationUser_Id1");
            RenameIndex(table: "dbo.Devices", name: "IX_HomeID", newName: "IX_Home_Id1");
            RenameColumn(table: "dbo.Homes", name: "ApplicationUserID", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.Devices", name: "HomeID", newName: "Home_Id1");
        }
    }
}
