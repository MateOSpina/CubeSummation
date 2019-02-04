namespace EntitiesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTestCases : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matrizs", t => t.Matriz_Id)
                .Index(t => t.Matriz_Id);
            
            AddColumn("dbo.Rows", "RowNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCases", "Matriz_Id", "dbo.Matrizs");
            DropIndex("dbo.TestCases", new[] { "Matriz_Id" });
            DropColumn("dbo.Rows", "RowNumber");
            DropTable("dbo.TestCases");
        }
    }
}
