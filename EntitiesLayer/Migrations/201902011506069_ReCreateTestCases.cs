namespace EntitiesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReCreateTestCases : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matrizs", "TestCase_Id", c => c.Int());
            CreateIndex("dbo.Matrizs", "TestCase_Id");
            AddForeignKey("dbo.Matrizs", "TestCase_Id", "dbo.TestCases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matrizs", "TestCase_Id", "dbo.TestCases");
            DropIndex("dbo.Matrizs", new[] { "TestCase_Id" });
            DropColumn("dbo.Matrizs", "TestCase_Id");
            DropTable("dbo.TestCases");
        }
    }
}
