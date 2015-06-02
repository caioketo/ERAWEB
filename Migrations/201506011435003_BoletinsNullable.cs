namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoletinsNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims");
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim1Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim2Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim3Id" });
            AlterColumn("dbo.BoletimModels", "NotaTrim1Id", c => c.Int());
            AlterColumn("dbo.BoletimModels", "NotaTrim2Id", c => c.Int());
            AlterColumn("dbo.BoletimModels", "NotaTrim3Id", c => c.Int());
            CreateIndex("dbo.BoletimModels", "NotaTrim1Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim2Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim3Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims", "Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims", "Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims");
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim3Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim2Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim1Id" });
            AlterColumn("dbo.BoletimModels", "NotaTrim3Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BoletimModels", "NotaTrim2Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BoletimModels", "NotaTrim1Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BoletimModels", "NotaTrim3Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim2Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim1Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BoletimModels", "NotaTrim1Id", "dbo.NotasBoletims", "Id", cascadeDelete: true);
        }
    }
}
