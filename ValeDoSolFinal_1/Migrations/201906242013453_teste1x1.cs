namespace ValeDoSolFinal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste1x1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leitura", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Lote", "Proprietario", c => c.String(nullable: false, maxLength: 140));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumoes", "Id", "dbo.Leitura");
            DropIndex("dbo.Consumoes", new[] { "Id" });
            DropColumn("dbo.Lote", "Proprietario");
            DropTable("dbo.Consumoes");
        }
    }
}
