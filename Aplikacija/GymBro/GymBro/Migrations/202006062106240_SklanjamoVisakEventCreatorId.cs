namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SklanjamoVisakEventCreatorId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "EventCreator_Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventCreator_Id", c => c.String(maxLength: 128));
        }
    }
}
