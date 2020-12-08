namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createSlotModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailableFrom = c.DateTime(nullable: false),
                        AvailableTill = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Slots", new[] { "ApplicationUserId" });
            DropTable("dbo.Slots");
        }
    }
}
