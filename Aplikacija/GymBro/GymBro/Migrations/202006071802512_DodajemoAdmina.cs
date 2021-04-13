namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajemoAdmina : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Event_Id], [Town], [AverageRating]) VALUES (N'010ab709-ad98-4819-9a6e-286bfcf4d63f', N'Nina', N'Nesic', N'nina.nesic@elfak.rs', 0, N'AHaPaGP7aB9jxi6e9765FyDELMnqY98W3Tex1OR4nF+92ZWVj0FNONp5wCnu/PmMBQ==', N'fbb47f89-b6fc-4c55-a765-72904b4e48e6', NULL, 0, 0, NULL, 1, 0, N'nina.nesic@elfak.rs', NULL, N'Nis', 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Event_Id], [Town], [AverageRating]) VALUES (N'ef29ad26-3b3f-4ef5-b801-136a19b37a8e', N'Admin', N'GymBro', N'admin@gymbro.rs', 0, N'AHaIy6KnY6CGHyh+A8KT5FITG3eiFo9g4kZs15fFg74N8KEC+smYIYEgF2Uw27tuag==', N'6d4cc791-8f9a-443f-ba9e-7040b54f5464', NULL, 0, 0, NULL, 1, 0, N'admin@gymbro.rs', NULL, N'Nis', 0)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7dd55ee3-272b-4e80-9a33-71a324417215', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ef29ad26-3b3f-4ef5-b801-136a19b37a8e', N'7dd55ee3-272b-4e80-9a33-71a324417215')

");
        }
        
        public override void Down()
        {
        }
    }
}
