namespace Upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustePropriedades : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fotoes", "Base64");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fotoes", "Base64", c => c.String());
        }
    }
}
