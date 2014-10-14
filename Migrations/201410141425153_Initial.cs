namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArquivoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Arquivo = c.String(),
                        Descricao = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AvisoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aviso = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TurmaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        CursoId = c.Int(nullable: false),
                        Serie = c.Int(nullable: false),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CursoModels", t => t.CursoId, cascadeDelete: true)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.CursoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ano = c.Int(nullable: false),
                        PeriodoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                        PrimeiraSerie = c.Int(nullable: false),
                        UltimaSerie = c.Int(nullable: false),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PeriodoModels", t => t.PeriodoId, cascadeDelete: true)
                .ForeignKey("dbo.UnidadeModels", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.PeriodoId)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.PeriodoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        HoraInicio = c.String(),
                        HoraFim = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        DataEvento = c.DateTime(nullable: false),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                        Conteudo = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisciplinaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Abreviatura = c.String(),
                        NomeHistorico = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicaoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataLicao = c.DateTime(nullable: false),
                        Conteudo = c.String(),
                        DisciplinaId = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisciplinaModels", t => t.DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.TurmaModels", t => t.TurmaId, cascadeDelete: true)
                .Index(t => t.DisciplinaId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.ProvaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataProva = c.DateTime(nullable: false),
                        Trimestre = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                        DisciplinaId = c.Int(nullable: false),
                        Recuperacao = c.Boolean(nullable: false),
                        Descricao = c.String(),
                        DataExclusao = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DisciplinaModels", t => t.DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.TurmaModels", t => t.TurmaId, cascadeDelete: true)
                .Index(t => t.DisciplinaId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.AvisoModelArquivoModels",
                c => new
                    {
                        AvisoModel_Id = c.Int(nullable: false),
                        ArquivoModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvisoModel_Id, t.ArquivoModel_Id })
                .ForeignKey("dbo.AvisoModels", t => t.AvisoModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.ArquivoModels", t => t.ArquivoModel_Id, cascadeDelete: true)
                .Index(t => t.AvisoModel_Id)
                .Index(t => t.ArquivoModel_Id);
            
            CreateTable(
                "dbo.EventoModelTurmaModels",
                c => new
                    {
                        EventoModel_Id = c.Int(nullable: false),
                        TurmaModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventoModel_Id, t.TurmaModel_Id })
                .ForeignKey("dbo.EventoModels", t => t.EventoModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.TurmaModels", t => t.TurmaModel_Id, cascadeDelete: true)
                .Index(t => t.EventoModel_Id)
                .Index(t => t.TurmaModel_Id);
            
            CreateTable(
                "dbo.AvisoModelTurmaModels",
                c => new
                    {
                        AvisoModel_Id = c.Int(nullable: false),
                        TurmaModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvisoModel_Id, t.TurmaModel_Id })
                .ForeignKey("dbo.AvisoModels", t => t.AvisoModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.TurmaModels", t => t.TurmaModel_Id, cascadeDelete: true)
                .Index(t => t.AvisoModel_Id)
                .Index(t => t.TurmaModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProvaModels", "TurmaId", "dbo.TurmaModels");
            DropForeignKey("dbo.ProvaModels", "DisciplinaId", "dbo.DisciplinaModels");
            DropForeignKey("dbo.LicaoModels", "TurmaId", "dbo.TurmaModels");
            DropForeignKey("dbo.LicaoModels", "DisciplinaId", "dbo.DisciplinaModels");
            DropForeignKey("dbo.AvisoModelTurmaModels", "TurmaModel_Id", "dbo.TurmaModels");
            DropForeignKey("dbo.AvisoModelTurmaModels", "AvisoModel_Id", "dbo.AvisoModels");
            DropForeignKey("dbo.EventoModelTurmaModels", "TurmaModel_Id", "dbo.TurmaModels");
            DropForeignKey("dbo.EventoModelTurmaModels", "EventoModel_Id", "dbo.EventoModels");
            DropForeignKey("dbo.CursoModels", "UnidadeId", "dbo.UnidadeModels");
            DropForeignKey("dbo.TurmaModels", "CursoId", "dbo.CursoModels");
            DropForeignKey("dbo.CursoModels", "PeriodoId", "dbo.PeriodoModels");
            DropForeignKey("dbo.AvisoModelArquivoModels", "ArquivoModel_Id", "dbo.ArquivoModels");
            DropForeignKey("dbo.AvisoModelArquivoModels", "AvisoModel_Id", "dbo.AvisoModels");
            DropIndex("dbo.ProvaModels", new[] { "TurmaId" });
            DropIndex("dbo.ProvaModels", new[] { "DisciplinaId" });
            DropIndex("dbo.LicaoModels", new[] { "TurmaId" });
            DropIndex("dbo.LicaoModels", new[] { "DisciplinaId" });
            DropIndex("dbo.AvisoModelTurmaModels", new[] { "TurmaModel_Id" });
            DropIndex("dbo.AvisoModelTurmaModels", new[] { "AvisoModel_Id" });
            DropIndex("dbo.EventoModelTurmaModels", new[] { "TurmaModel_Id" });
            DropIndex("dbo.EventoModelTurmaModels", new[] { "EventoModel_Id" });
            DropIndex("dbo.CursoModels", new[] { "UnidadeId" });
            DropIndex("dbo.TurmaModels", new[] { "CursoId" });
            DropIndex("dbo.CursoModels", new[] { "PeriodoId" });
            DropIndex("dbo.AvisoModelArquivoModels", new[] { "ArquivoModel_Id" });
            DropIndex("dbo.AvisoModelArquivoModels", new[] { "AvisoModel_Id" });
            DropTable("dbo.AvisoModelTurmaModels");
            DropTable("dbo.EventoModelTurmaModels");
            DropTable("dbo.AvisoModelArquivoModels");
            DropTable("dbo.ProvaModels");
            DropTable("dbo.LicaoModels");
            DropTable("dbo.DisciplinaModels");
            DropTable("dbo.EventoModels");
            DropTable("dbo.UnidadeModels");
            DropTable("dbo.PeriodoModels");
            DropTable("dbo.CursoModels");
            DropTable("dbo.TurmaModels");
            DropTable("dbo.AvisoModels");
            DropTable("dbo.ArquivoModels");
        }
    }
}
