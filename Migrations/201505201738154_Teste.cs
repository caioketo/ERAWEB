namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoletimModels", "Disciplina_Id", "dbo.DisciplinaModels");
            DropForeignKey("dbo.BoletimModels", "NotaTrim1_Id", "dbo.NotasBoletims");
            DropIndex("dbo.BoletimModels", new[] { "Disciplina_Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim1_Id" });
            RenameColumn(table: "dbo.BoletimModels", name: "Disciplina_Id", newName: "DisciplinaId");
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim1_Id", newName: "NotaTrim1Id");
            AddColumn("dbo.BoletimModels", "AlunoId", c => c.Int(nullable: false));
            AlterColumn("dbo.BoletimModels", "DisciplinaId", c => c.Int(nullable: false));
            AlterColumn("dbo.BoletimModels", "NotaTrim1Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BoletimModels", "DisciplinaId");
            CreateIndex("dbo.BoletimModels", "NotaTrim1Id");
            AddForeignKey("dbo.BoletimModels", "DisciplinaId", "dbo.DisciplinaModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "DisciplinaId", "dbo.DisciplinaModels");
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim1Id" });
            DropIndex("dbo.BoletimModels", new[] { "DisciplinaId" });
            AlterColumn("dbo.BoletimModels", "NotaTrim1Id", c => c.Int());
            AlterColumn("dbo.BoletimModels", "DisciplinaId", c => c.Int());
            DropColumn("dbo.BoletimModels", "AlunoId");
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim1Id", newName: "NotaTrim1_Id");
            RenameColumn(table: "dbo.BoletimModels", name: "DisciplinaId", newName: "Disciplina_Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim1_Id");
            CreateIndex("dbo.BoletimModels", "Disciplina_Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim1_Id", "dbo.NotasBoletims", "Id");
            AddForeignKey("dbo.BoletimModels", "Disciplina_Id", "dbo.DisciplinaModels", "Id");
        }
    }
}
