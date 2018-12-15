namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notificaties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notificatie",
                c => new
                    {
                        NotificatieId = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Toegevoegd = c.DateTime(nullable: false),
                        StartDatum = c.DateTime(nullable: false),
                        Abonnement_AbonnementId = c.Int(),
                    })
                .PrimaryKey(t => t.NotificatieId)
                .ForeignKey("dbo.Abonnement", t => t.Abonnement_AbonnementId)
                .Index(t => t.Abonnement_AbonnementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notificatie", "Abonnement_AbonnementId", "dbo.Abonnement");
            DropIndex("dbo.Notificatie", new[] { "Abonnement_AbonnementId" });
            DropTable("dbo.Notificatie");
        }
    }
}
