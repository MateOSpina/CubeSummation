namespace EntitiesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatrizAndRow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matrizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operations = c.Int(nullable: false),
                        Executed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Column = c.String(),
                        Value = c.Int(nullable: false),
                        Matriz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matrizs", t => t.Matriz_Id)
                .Index(t => t.Matriz_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rows", "Matriz_Id", "dbo.Matrizs");
            DropIndex("dbo.Rows", new[] { "Matriz_Id" });
            DropTable("dbo.Rows");
            DropTable("dbo.Matrizs");
        }
    }
}
