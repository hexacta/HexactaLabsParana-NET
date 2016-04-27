namespace CapacitacionMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_movie_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Plot", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "CoverLink", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "Runtime", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "Runtime");
            DropColumn("dbo.Movies", "CoverLink");
            DropColumn("dbo.Movies", "Plot");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
