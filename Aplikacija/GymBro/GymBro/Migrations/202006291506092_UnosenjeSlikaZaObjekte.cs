namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnosenjeSlikaZaObjekte : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/index1.jpg', 1)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/index2.jpg', 1)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/index4.jpg', 1)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/index4.jpg', 1)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/topform1.jpg', 10)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/topform2.jpg', 10)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/topform3.jpg', 10)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/topform4.jpg', 10)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/topform5.jpg', 10)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gold1.jpg', 12)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gold2.jpg', 12)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gold3.jpg', 12)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/kangoo1.jpg', 13)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/kangoo2.jpg', 13)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/kangoo3.jpg', 13)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/kangoo4.jpg', 13)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/fitlab1.jpg', 14)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/fitlab2.jpg', 14)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/fitlab3.jpg', 14)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/factory1.jpg', 20)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/factory2.jpg', 20)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/factory3.jpg', 20)");
        }
        
        public override void Down()
        {
        }
    }
}
