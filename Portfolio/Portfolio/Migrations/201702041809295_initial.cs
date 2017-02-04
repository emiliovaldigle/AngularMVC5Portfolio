namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        idArticle = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idArticle);
            
            CreateTable(
                "dbo.Biographies",
                c => new
                    {
                        idBiography = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idBiography);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        idCategory = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.idCategory);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        idCompetence = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        idCategory = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.idCompetence)
                .ForeignKey("dbo.Categories", t => t.idCategory, cascadeDelete: true)
                .Index(t => t.idCategory);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        idClient = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.idClient);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        idProject = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        idClient = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.idProject)
                .ForeignKey("dbo.Clients", t => t.idClient, cascadeDelete: true)
                .Index(t => t.idClient);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        idImage = c.Guid(nullable: false, identity: true),
                        Path = c.String(),
                        idProject = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.idImage)
                .ForeignKey("dbo.Projects", t => t.idProject, cascadeDelete: true)
                .Index(t => t.idProject);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        idContact = c.Guid(nullable: false, identity: true),
                        Mail = c.String(),
                        Enterprise = c.String(),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idContact);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Images", "idProject", "dbo.Projects");
            DropForeignKey("dbo.Projects", "idClient", "dbo.Clients");
            DropForeignKey("dbo.Competences", "idCategory", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Images", new[] { "idProject" });
            DropIndex("dbo.Projects", new[] { "idClient" });
            DropIndex("dbo.Competences", new[] { "idCategory" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Contacts");
            DropTable("dbo.Images");
            DropTable("dbo.Projects");
            DropTable("dbo.Clients");
            DropTable("dbo.Competences");
            DropTable("dbo.Categories");
            DropTable("dbo.Biographies");
            DropTable("dbo.Articles");
        }
    }
}
