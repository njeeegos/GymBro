namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestProveraBilaUspesna : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "TestAtr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TestAtr", c => c.Int(nullable: false));
        }
    }
}
