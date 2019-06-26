namespace ValeDoSolFinal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AceitandoNuloData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Consumoes", "DataPagamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consumoes", "DataPagamento", c => c.DateTime(nullable: false));
        }
    }
}
