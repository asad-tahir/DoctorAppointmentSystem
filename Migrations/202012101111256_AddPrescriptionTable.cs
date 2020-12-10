namespace DoctorAppointmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Doctor_Id = c.String(maxLength: 128),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Doctor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Prescriptions", "Doctor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Prescriptions", new[] { "Patient_Id" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_Id" });
            DropTable("dbo.Prescriptions");
        }
    }
}
