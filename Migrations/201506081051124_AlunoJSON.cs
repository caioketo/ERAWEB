namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunoJSON : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Codigo = c.String(),
                        UPCATNT = c.String(),
                        CId = c.Int(nullable: false),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlunoModels");
        }
    }
}
