namespace PetProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productcategoryImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "Image", c => c.String());
            DropColumn("dbo.ProductCategories", "URLImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "URLImage", c => c.String());
            AlterColumn("dbo.ProductCategories", "Image", c => c.String(maxLength: 256));
        }
    }
}
