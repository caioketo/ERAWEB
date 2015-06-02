namespace ERAWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Boletins : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoletimModels", "NotaTrim2_Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim3_Id", "dbo.NotasBoletims");
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim2_Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim3_Id" });
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim2_Id", newName: "NotaTrim2Id");
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim3_Id", newName: "NotaTrim3Id");
            AlterColumn("dbo.BoletimModels", "NotaTrim2Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BoletimModels", "NotaTrim3Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BoletimModels", "NotaTrim2Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim3Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoletimModels", "NotaTrim3Id", "dbo.NotasBoletims");
            DropForeignKey("dbo.BoletimModels", "NotaTrim2Id", "dbo.NotasBoletims");
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim3Id" });
            DropIndex("dbo.BoletimModels", new[] { "NotaTrim2Id" });
            AlterColumn("dbo.BoletimModels", "NotaTrim3Id", c => c.Int());
            AlterColumn("dbo.BoletimModels", "NotaTrim2Id", c => c.Int());
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim3Id", newName: "NotaTrim3_Id");
            RenameColumn(table: "dbo.BoletimModels", name: "NotaTrim2Id", newName: "NotaTrim2_Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim3_Id");
            CreateIndex("dbo.BoletimModels", "NotaTrim2_Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim3_Id", "dbo.NotasBoletims", "Id");
            AddForeignKey("dbo.BoletimModels", "NotaTrim2_Id", "dbo.NotasBoletims", "Id");
        }
    }
}
