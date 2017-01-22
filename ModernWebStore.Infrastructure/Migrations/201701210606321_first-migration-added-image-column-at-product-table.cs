namespace ModernWebStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigrationaddedimagecolumnatproducttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Image", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Product", "Image");
        }
    }
}
