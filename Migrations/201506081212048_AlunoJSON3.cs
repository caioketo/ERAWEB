namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunoJSON3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoletimModels", "AlunoCId", c => c.Int(nullable: false));
            AddColumn("dbo.BoletimModels", "Aluno_Id", c => c.Int());
            AddColumn("dbo.BoletimModels", "Aluno_CId", c => c.Int());
            AlterColumn("dbo.AlunoModels", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.AlunoModels");
            AddPrimaryKey("dbo.AlunoModels", new[] { "Id", "CId" });
            CreateIndex("dbo.BoletimModels", new[] { "Aluno_Id", "Aluno_CId" });
            AddForeignKey("dbo.BoletimModels", new[] { "Aluno_Id", "Aluno_CId" }, "dbo.AlunoModels", new[] { "Id", "CId" });
            DropColumn("dbo.BoletimModels", "AlunoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BoletimModels", "AlunoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BoletimModels", new[] { "Aluno_Id", "Aluno_CId" }, "dbo.AlunoModels");
            DropIndex("dbo.BoletimModels", new[] { "Aluno_Id", "Aluno_CId" });
            DropPrimaryKey("dbo.AlunoModels");
            AddPrimaryKey("dbo.AlunoModels", "Id");
            AlterColumn("dbo.AlunoModels", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.BoletimModels", "Aluno_CId");
            DropColumn("dbo.BoletimModels", "Aluno_Id");
            DropColumn("dbo.BoletimModels", "AlunoCId");
        }
    }
}
