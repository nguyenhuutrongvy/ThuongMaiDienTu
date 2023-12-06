namespace OnlineCosmetic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProductCategoryFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "Alias", c => c.String());
            AddColumn("dbo.ProductCategory", "SEOTitle", c => c.String());
            AddColumn("dbo.ProductCategory", "SEODescription", c => c.String());
            AddColumn("dbo.ProductCategory", "SEOKeywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategory", "SEOKeywords");
            DropColumn("dbo.ProductCategory", "SEODescription");
            DropColumn("dbo.ProductCategory", "SEOTitle");
            DropColumn("dbo.ProductCategory", "Alias");
        }
    }
}
