namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAppointmentRequestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        SlotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Slots", t => t.SlotId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SlotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.Appointments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "SlotId" });
            DropIndex("dbo.Appointments", new[] { "ApplicationUserId" });
            DropTable("dbo.Appointments");
        }
    }
}
