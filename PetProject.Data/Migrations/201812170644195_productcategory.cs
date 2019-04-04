namespace PetProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "URLImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "URLImage");
        }
    }
}
