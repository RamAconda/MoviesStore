namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddpropertiestoMovieclassandcreateGenreclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreLkps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        GenreLkpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreLkps", t => t.GenreLkpId, cascadeDelete: true)
                .Index(t => t.GenreLkpId);

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreLkpId", "dbo.GenreLkps");
            DropIndex("dbo.Movies", new[] { "GenreLkpId" });
            DropTable("dbo.Movies");
            DropTable("dbo.GenreLkps");
        }
    }
}
