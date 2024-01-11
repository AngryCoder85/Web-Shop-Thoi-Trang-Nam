namespace HLTClothes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Long(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Long(nullable: false, identity: true),
                        GenerName = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        BrandID = c.Long(),
                        GenderID = c.Long(),
                        CategoryID = c.Long(),
                        SizeID = c.Long(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateOfUpload = c.DateTime(),
                        DateOfPurchase = c.DateTime(),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        ShowOnIndex = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Genders", t => t.GenderID)
                .ForeignKey("dbo.Sizes", t => t.SizeID)
                .Index(t => t.BrandID)
                .Index(t => t.GenderID)
                .Index(t => t.CategoryID)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Long(nullable: false, identity: true),
                        SizeName = c.String(),
                    })
                .PrimaryKey(t => t.SizeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.Products", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "SizeID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "GenderID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropTable("dbo.Sizes");
            DropTable("dbo.Products");
            DropTable("dbo.Genders");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
