namespace ValeDoSolFinal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relacionamento1N : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leituras", "LoteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Leituras", "LoteId");
            AddForeignKey("dbo.Leituras", "LoteId", "dbo.Lotes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leituras", "LoteId", "dbo.Lotes");
            DropIndex("dbo.Leituras", new[] { "LoteId" });
            DropColumn("dbo.Leituras", "LoteId");
        }
    }
}
