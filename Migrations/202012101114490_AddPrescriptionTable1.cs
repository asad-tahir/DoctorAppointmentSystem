namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTable1 : DbMigration
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
