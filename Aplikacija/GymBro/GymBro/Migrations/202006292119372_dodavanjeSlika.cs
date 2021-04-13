namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodavanjeSlika : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/dusko1.jpg', 6)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/dusko2.jpg', 6)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/dusko3.jpg', 6)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/dusko4.jpg', 6)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gymtown1.jpg', 19)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gymtown2.jpg', 19)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gymtown3.jpg', 19)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gymtown4.jpg', 19)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/gymtown5.jpg', 19)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/mika1.jpg', 5)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/mika2.jpg', 5)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/mika3.jpg', 5)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/mika4.jpg', 5)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/mika5.jpg', 5)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/rovce1.jpg', 22)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/rovce2.jpg', 22)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/rovce3.jpg', 22)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/strongman1.jpg', 15)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/strongman2.jpg', 15)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/strongman3.jpg', 15)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/svetisava1.jpg', 21)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/svetisava2.jpg', 21)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/svetisava3.jpg', 21)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/teniskej1.jpg', 16)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/teniskej2.jpg', 16)");
            Sql("INSERT INTO FacilityImages (Path, SportsFacilityId) VALUES ('../../Content/FacilityImages/teniskej3.jpg', 16)");
        }
        
        public override void Down()
        {
        }
    }
}
