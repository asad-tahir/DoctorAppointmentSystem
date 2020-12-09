namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailableColumnToSlot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slots", "Available");
        }
    }
}
