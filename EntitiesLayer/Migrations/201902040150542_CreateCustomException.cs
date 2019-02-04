namespace EntitiesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCustomException : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomExceptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomExceptions");
        }
    }
}
