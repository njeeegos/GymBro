namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatiNoviPropertijiUModele : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CurrentNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.SportsFacilities", "Town", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SportsFacilities", "Town");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Birthdate");
            DropColumn("dbo.Events", "CurrentNumber");
        }
    }
}
