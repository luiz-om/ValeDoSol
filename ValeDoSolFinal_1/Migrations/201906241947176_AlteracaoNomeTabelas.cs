namespace ValeDoSolFinal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoNomeTabelas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Leituras", newName: "Leitura");
            RenameTable(name: "dbo.Lotes", newName: "Lote");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Lote", newName: "Lotes");
            RenameTable(name: "dbo.Leitura", newName: "Leituras");
        }
    }
}
