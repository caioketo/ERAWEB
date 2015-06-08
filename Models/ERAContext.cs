using ERAWeb.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERAWeb.Models
{
    public class ERAContext : DbContext
    {

        public string teste;
        private static ERAContext context;
        public static ERAContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new ERAContext();
                }
                return context;
            }
        }


        public static string CreateConnectionString()
        {
            return "DefaultConnection";
        }
        private string connectionString;
        public ERAContext() : base(CreateConnectionString()) 
        {
            connectionString = CreateConnectionString();
            teste = connectionString;
        }
        public ERAContext(string nameOrConnectionString)
            : base(nameOrConnectionString) 
        {
            connectionString = nameOrConnectionString;
            teste = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ERAContext>(new MigrateDatabaseToLatestVersion<ERAContext, Configuration>());
            //Database.SetInitializer<ERAContext>(new DropCreateDatabaseAlways<ERAContext>());
            modelBuilder.Entity<EventoModel>()
                .HasMany(a => a.Turmas)
                .WithMany(b => b.Eventos);
            modelBuilder.Entity<AvisoModel>()
                .HasMany(a => a.Turmas)
                .WithMany(b => b.Avisos);
            modelBuilder.Entity<AvisoModel>()
                .HasMany(a => a.Arquivos)
                .WithMany(b => b.Avisos);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LicaoModel> Licoes { get; set; }
        public DbSet<ProvaModel> Provas { get; set; }
        public DbSet<DisciplinaModel> DisciplinaModels { get; set; }
        public DbSet<TurmaModel> TurmaModels { get; set; }
        public DbSet<ERAWeb.Models.EventoModel> EventoModels { get; set; }
        public DbSet<ERAWeb.Models.AvisoModel> AvisoModels { get; set; }
        public DbSet<ERAWeb.Models.ArquivoModel> ArquivoModels { get; set; }
        public DbSet<ERAWeb.Models.CursoModel> CursoModels { get; set; }
        public DbSet<ERAWeb.Models.BoletimModel> BoletimModels { get; set; }
        public DbSet<AlunoModel> AlunoModels { get; set; }

    }
}