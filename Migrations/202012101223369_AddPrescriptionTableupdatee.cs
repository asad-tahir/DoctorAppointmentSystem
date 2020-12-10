namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTableupdatee : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Prescriptions", new[] { "Doctor_Id" });
            DropColumn("dbo.Prescriptions", "DoctorId");
            RenameColumn(table: "dbo.Prescriptions", name: "Doctor_Id", newName: "DoctorId");
            AlterColumn("dbo.Prescriptions", "DoctorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Prescriptions", "DoctorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            AlterColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Prescriptions", name: "DoctorId", newName: "Doctor_Id");
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescriptions", "Doctor_Id");
        }
    }
}
