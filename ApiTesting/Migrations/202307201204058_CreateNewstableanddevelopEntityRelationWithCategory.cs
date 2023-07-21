namespace ApiTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewstableanddevelopEntityRelationWithCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Cat_Id, cascadeDelete: true)
                .Index(t => t.Cat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Cat_Id", "dbo.Categories");
            DropIndex("dbo.News", new[] { "Cat_Id" });
            DropTable("dbo.News");
        }
    }
}
