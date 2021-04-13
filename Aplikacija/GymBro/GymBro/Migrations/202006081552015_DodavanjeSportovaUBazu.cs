namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodavanjeSportovaUBazu : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sports (Name) VALUES ('Fitnes')");
            Sql("INSERT INTO Sports (Name) VALUES ('Trcanje')");
            Sql("INSERT INTO Sports (Name) VALUES ('Mali fudbal')");
            Sql("INSERT INTO Sports (Name) VALUES ('Kosarka')");
            Sql("INSERT INTO Sports (Name) VALUES ('Tenis')");
            Sql("INSERT INTO Sports (Name) VALUES ('Stoni tenis')");
            Sql("INSERT INTO Sports (Name) VALUES ('Odbojka')");
        }
        
        public override void Down()
        {
        }
    }
}
