namespace EntitiesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTestCase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestCases", "Matriz_Id", "dbo.Matrizs");
            DropIndex("dbo.TestCases", new[] { "Matriz_Id" });
            DropTable("dbo.TestCases");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cases = c.Int(nullable: false),
                        Executed = c.Int(nullable: false),
                        Matriz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TestCases", "Matriz_Id");
            AddForeignKey("dbo.TestCases", "Matriz_Id", "dbo.Matrizs", "Id");
        }
    }
}
