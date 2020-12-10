namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTableupdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Prescriptions", name: "Patient_Id", newName: "PatientId");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_Patient_Id", newName: "IX_PatientId");
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.Prescriptions", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescriptions", "Description", c => c.String());
            DropColumn("dbo.Prescriptions", "DoctorId");
            RenameIndex(table: "dbo.Prescriptions", name: "IX_PatientId", newName: "IX_Patient_Id");
            RenameColumn(table: "dbo.Prescriptions", name: "PatientId", newName: "Patient_Id");
        }
    }
}
