namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ocenjivanje1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SportsFacilities", "AverageGrade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SportsFacilities", "AverageGrade", c => c.Double(nullable: false));
        }
    }
}
