namespace EFitnessMonitoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomeniuAntrenamente",
                c => new
                    {
                        Id_antrenament = c.Int(nullable: false),
                        Nume_antrenament = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_antrenament)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GraficAntrenament",
                c => new
                    {
                        Id_grafic = c.Int(nullable: false),
                        Id_antrenament = c.Int(nullable: false),
                        Titlu = c.String(nullable: false, maxLength: 50),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_grafic)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.DomeniuAntrenamente", t => t.Id_antrenament)
                .Index(t => t.Id_antrenament)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gen = c.String(nullable: false, maxLength: 50),
                        Virsta = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaimIntPks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.DomeniuSanatate",
                c => new
                    {
                        Id_categorie = c.Int(nullable: false),
                        Nume_categorie = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_categorie)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Medicina",
                c => new
                    {
                        Id_maladie = c.Int(nullable: false),
                        Id_categorie = c.Int(nullable: false),
                        Nume_maladie = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_maladie)
                .ForeignKey("dbo.DomeniuSanatate", t => t.Id_categorie)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.Id_categorie)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExercitiiSpeciale",
                c => new
                    {
                        Id_exSpecial = c.Int(nullable: false),
                        Id_maladie = c.Int(nullable: false),
                        Nume_exercitiu = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_exSpecial)
                .ForeignKey("dbo.Medicina", t => t.Id_maladie)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.Id_maladie)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Nutritie",
                c => new
                    {
                        Id_aliment = c.Int(nullable: false),
                        Id_categorie = c.Int(nullable: false),
                        Nume_aliment = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_aliment)
                .ForeignKey("dbo.DomeniuSanatate", t => t.Id_categorie)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.Id_categorie)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DomeniuSport",
                c => new
                    {
                        Id_muschi = c.Int(nullable: false),
                        Nume_muschi = c.String(nullable: false, maxLength: 20),
                        Descriere = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_muschi)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Warkout",
                c => new
                    {
                        Id_exercitiu = c.Int(nullable: false),
                        id_muschi = c.Int(nullable: false),
                        Nume_exercitiu = c.String(nullable: false, maxLength: 30),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_exercitiu)
                .ForeignKey("dbo.DomeniuSport", t => t.id_muschi)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.id_muschi)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLoginIntPks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Produse",
                c => new
                    {
                        Id_produs = c.Int(nullable: false),
                        Nume_produs = c.String(nullable: false, maxLength: 30),
                        Descriere = c.String(nullable: false, maxLength: 50),
                        Linq = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_produs)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoleIntPks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleIntPks", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleIntPks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubiecteForum",
                c => new
                    {
                        Id_subiect = c.Int(nullable: false),
                        Subiect = c.String(nullable: false, maxLength: 50),
                        Comntariu = c.String(nullable: false, unicode: false, storeType: "text"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_subiect)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comentarii",
                c => new
                    {
                        Id_subiect = c.Int(nullable: false),
                        Id_user = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_subiect, t.Id_user })
                .ForeignKey("dbo.SubiecteForum", t => t.Id_subiect, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id_user, cascadeDelete: true)
                .Index(t => t.Id_subiect)
                .Index(t => t.Id_user);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GraficAntrenament", "Id_antrenament", "dbo.DomeniuAntrenamente");
            DropForeignKey("dbo.Warkout", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.SubiecteForum", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Comentarii", "Id_user", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Comentarii", "Id_subiect", "dbo.SubiecteForum");
            DropForeignKey("dbo.UserRoleIntPks", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserRoleIntPks", "RoleId", "dbo.RoleIntPks");
            DropForeignKey("dbo.Produse", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Nutritie", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Medicina", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserLoginIntPks", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.GraficAntrenament", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ExercitiiSpeciale", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.DomeniuSport", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Warkout", "id_muschi", "dbo.DomeniuSport");
            DropForeignKey("dbo.DomeniuSanatate", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Nutritie", "Id_categorie", "dbo.DomeniuSanatate");
            DropForeignKey("dbo.Medicina", "Id_categorie", "dbo.DomeniuSanatate");
            DropForeignKey("dbo.ExercitiiSpeciale", "Id_maladie", "dbo.Medicina");
            DropForeignKey("dbo.DomeniuAntrenamente", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserClaimIntPks", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.Comentarii", new[] { "Id_user" });
            DropIndex("dbo.Comentarii", new[] { "Id_subiect" });
            DropIndex("dbo.SubiecteForum", new[] { "UserId" });
            DropIndex("dbo.UserRoleIntPks", new[] { "RoleId" });
            DropIndex("dbo.UserRoleIntPks", new[] { "UserId" });
            DropIndex("dbo.Produse", new[] { "UserId" });
            DropIndex("dbo.UserLoginIntPks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Warkout", new[] { "UserId" });
            DropIndex("dbo.Warkout", new[] { "id_muschi" });
            DropIndex("dbo.DomeniuSport", new[] { "UserId" });
            DropIndex("dbo.Nutritie", new[] { "UserId" });
            DropIndex("dbo.Nutritie", new[] { "Id_categorie" });
            DropIndex("dbo.ExercitiiSpeciale", new[] { "UserId" });
            DropIndex("dbo.ExercitiiSpeciale", new[] { "Id_maladie" });
            DropIndex("dbo.Medicina", new[] { "UserId" });
            DropIndex("dbo.Medicina", new[] { "Id_categorie" });
            DropIndex("dbo.DomeniuSanatate", new[] { "UserId" });
            DropIndex("dbo.UserClaimIntPks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GraficAntrenament", new[] { "UserId" });
            DropIndex("dbo.GraficAntrenament", new[] { "Id_antrenament" });
            DropIndex("dbo.DomeniuAntrenamente", new[] { "UserId" });
            DropTable("dbo.Comentarii");
            DropTable("dbo.SubiecteForum");
            DropTable("dbo.RoleIntPks");
            DropTable("dbo.UserRoleIntPks");
            DropTable("dbo.Produse");
            DropTable("dbo.UserLoginIntPks");
            DropTable("dbo.Warkout");
            DropTable("dbo.DomeniuSport");
            DropTable("dbo.Nutritie");
            DropTable("dbo.ExercitiiSpeciale");
            DropTable("dbo.Medicina");
            DropTable("dbo.DomeniuSanatate");
            DropTable("dbo.UserClaimIntPks");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.GraficAntrenament");
            DropTable("dbo.DomeniuAntrenamente");
        }
    }
}
