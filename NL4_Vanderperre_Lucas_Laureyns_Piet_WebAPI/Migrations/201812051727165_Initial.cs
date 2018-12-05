namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnement",
                c => new
                    {
                        AbonnementId = c.Int(nullable: false, identity: true),
                        Onderneming_OndenemingId = c.Int(),
                        Klant_GebruikerId = c.Int(),
                    })
                .PrimaryKey(t => t.AbonnementId)
                .ForeignKey("dbo.Onderneming", t => t.Onderneming_OndenemingId)
                .ForeignKey("dbo.Klant", t => t.Klant_GebruikerId)
                .Index(t => t.Onderneming_OndenemingId)
                .Index(t => t.Klant_GebruikerId);
            
            CreateTable(
                "dbo.Onderneming",
                c => new
                    {
                        OndenemingId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Categorie = c.Int(nullable: false),
                        Soort = c.String(),
                        Facebook = c.String(),
                        Ondernemer_GebruikerId = c.Int(),
                    })
                .PrimaryKey(t => t.OndenemingId)
                .ForeignKey("dbo.Ondernemer", t => t.Ondernemer_GebruikerId)
                .Index(t => t.Ondernemer_GebruikerId);
            
            CreateTable(
                "dbo.Adres",
                c => new
                    {
                        AdresId = c.Int(nullable: false, identity: true),
                        Straat = c.String(),
                        Nummer = c.Int(nullable: false),
                        Postcode = c.Int(nullable: false),
                        Stad = c.String(),
                        Land = c.String(),
                        Onderneming_OndenemingId = c.Int(),
                    })
                .PrimaryKey(t => t.AdresId)
                .ForeignKey("dbo.Onderneming", t => t.Onderneming_OndenemingId)
                .Index(t => t.Onderneming_OndenemingId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Startdatum = c.DateTime(nullable: false),
                        Einddatum = c.DateTime(nullable: false),
                        Beschrijving = c.String(),
                        Onderneming_OndenemingId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Onderneming", t => t.Onderneming_OndenemingId)
                .Index(t => t.Onderneming_OndenemingId);
            
            CreateTable(
                "dbo.Openingsuren",
                c => new
                    {
                        OpeningsurenId = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        OpenTime = c.String(),
                        CloseTime = c.String(),
                        Onderneming_OndenemingId = c.Int(),
                    })
                .PrimaryKey(t => t.OpeningsurenId)
                .ForeignKey("dbo.Onderneming", t => t.Onderneming_OndenemingId)
                .Index(t => t.Onderneming_OndenemingId);
            
            CreateTable(
                "dbo.Promotie",
                c => new
                    {
                        PromotieId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Startdatum = c.DateTime(nullable: false),
                        Einddatum = c.DateTime(nullable: false),
                        Beschrijving = c.String(),
                        Barcode = c.String(),
                        Onderneming_OndenemingId = c.Int(),
                    })
                .PrimaryKey(t => t.PromotieId)
                .ForeignKey("dbo.Onderneming", t => t.Onderneming_OndenemingId)
                .Index(t => t.Onderneming_OndenemingId);
            
            CreateTable(
                "dbo.Gebruiker",
                c => new
                    {
                        GebruikerId = c.Int(nullable: false, identity: true),
                        naam = c.String(),
                        voornaam = c.String(),
                        username = c.String(),
                        password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Klant",
                c => new
                    {
                        GebruikerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GebruikerId)
                .ForeignKey("dbo.Gebruiker", t => t.GebruikerId)
                .Index(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Ondernemer",
                c => new
                    {
                        GebruikerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GebruikerId)
                .ForeignKey("dbo.Gebruiker", t => t.GebruikerId)
                .Index(t => t.GebruikerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ondernemer", "GebruikerId", "dbo.Gebruiker");
            DropForeignKey("dbo.Klant", "GebruikerId", "dbo.Gebruiker");
            DropForeignKey("dbo.Onderneming", "Ondernemer_GebruikerId", "dbo.Ondernemer");
            DropForeignKey("dbo.Abonnement", "Klant_GebruikerId", "dbo.Klant");
            DropForeignKey("dbo.Abonnement", "Onderneming_OndenemingId", "dbo.Onderneming");
            DropForeignKey("dbo.Promotie", "Onderneming_OndenemingId", "dbo.Onderneming");
            DropForeignKey("dbo.Openingsuren", "Onderneming_OndenemingId", "dbo.Onderneming");
            DropForeignKey("dbo.Event", "Onderneming_OndenemingId", "dbo.Onderneming");
            DropForeignKey("dbo.Adres", "Onderneming_OndenemingId", "dbo.Onderneming");
            DropIndex("dbo.Ondernemer", new[] { "GebruikerId" });
            DropIndex("dbo.Klant", new[] { "GebruikerId" });
            DropIndex("dbo.Promotie", new[] { "Onderneming_OndenemingId" });
            DropIndex("dbo.Openingsuren", new[] { "Onderneming_OndenemingId" });
            DropIndex("dbo.Event", new[] { "Onderneming_OndenemingId" });
            DropIndex("dbo.Adres", new[] { "Onderneming_OndenemingId" });
            DropIndex("dbo.Onderneming", new[] { "Ondernemer_GebruikerId" });
            DropIndex("dbo.Abonnement", new[] { "Klant_GebruikerId" });
            DropIndex("dbo.Abonnement", new[] { "Onderneming_OndenemingId" });
            DropTable("dbo.Ondernemer");
            DropTable("dbo.Klant");
            DropTable("dbo.Gebruiker");
            DropTable("dbo.Promotie");
            DropTable("dbo.Openingsuren");
            DropTable("dbo.Event");
            DropTable("dbo.Adres");
            DropTable("dbo.Onderneming");
            DropTable("dbo.Abonnement");
        }
    }
}
