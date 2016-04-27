namespace CapacitacionMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnewpropertiestoMovieentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Plot", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "CoverLink", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "Runtime", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Runtime");
            DropColumn("dbo.Movies", "CoverLink");
            DropColumn("dbo.Movies", "Plot");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
