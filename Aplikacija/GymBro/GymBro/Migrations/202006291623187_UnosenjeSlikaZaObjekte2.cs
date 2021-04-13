namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnosenjeSlikaZaObjekte2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SportsFacilities", "AverageGrade", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SportsFacilities", "AverageGrade");
        }
    }
}
