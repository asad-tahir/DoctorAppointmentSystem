namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTableupdat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescriptions", "Description");
        }
    }
}
