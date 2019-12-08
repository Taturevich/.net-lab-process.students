namespace EF_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Title = c.String(),
                        TitleOfCourtesy = c.String(),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        HomePhone = c.String(),
                        Extension = c.String(),
                        Photo = c.Binary(),
                        Notes = c.String(),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.EmployeeTerritories",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        TerritoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.TerritoryID });
            
            CreateTable(
                "dbo.Order Details",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(),
                        EmployeeID = c.Int(),
                        OrderDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        ShipVia = c.Int(),
                        Freight = c.Decimal(precision: 18, scale: 2),
                        ShipName = c.String(),
                        ShipAddress = c.String(),
                        ShipCity = c.String(),
                        ShipRegion = c.String(),
                        ShipPostalCode = c.String(),
                        ShipCountry = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        SupplierID = c.Int(),
                        CategoryID = c.Int(),
                        QuantityPerUnit = c.String(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitsInStock = c.Int(),
                        UnitsOnOrder = c.Int(),
                        ReorderLevel = c.Int(),
                        Discontinued = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        RegionDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        TerritoryID = c.Int(nullable: false, identity: true),
                        TerritoryDescription = c.String(nullable: false),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Territories");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Region");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Order Details");
            DropTable("dbo.EmployeeTerritories");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
