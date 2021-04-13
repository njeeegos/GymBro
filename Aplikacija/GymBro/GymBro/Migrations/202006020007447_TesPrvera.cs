namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesPrvera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TestAtr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "TestAtr");
        }
    }
}
