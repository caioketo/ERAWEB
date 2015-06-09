namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioSenha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlunoModels", "Email", c => c.String());
            AddColumn("dbo.AlunoModels", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlunoModels", "Senha");
            DropColumn("dbo.AlunoModels", "Email");
        }
    }
}
