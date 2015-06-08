namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunoJSON2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlunoModels", "UPCATN", c => c.String());
            AddColumn("dbo.AlunoModels", "Ano", c => c.Int(nullable: false));
            AddColumn("dbo.AlunoModels", "Turma", c => c.String());
            AddColumn("dbo.AlunoModels", "Numero", c => c.Int(nullable: false));
            DropColumn("dbo.AlunoModels", "UPCATNT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlunoModels", "UPCATNT", c => c.String());
            DropColumn("dbo.AlunoModels", "Numero");
            DropColumn("dbo.AlunoModels", "Turma");
            DropColumn("dbo.AlunoModels", "Ano");
            DropColumn("dbo.AlunoModels", "UPCATN");
        }
    }
}
