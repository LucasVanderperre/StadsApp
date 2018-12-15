namespace NL4_Vanderperre_Lucas_Laureyns_Piet_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notificaties1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notificatie", "Gelezen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notificatie", "Gelezen");
        }
    }
}
