using EF_Task.Entities;
using System.Data.Entity.Migrations;

namespace EF_Task.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = nameof(NorthwindContext);
        }

        protected override void Seed(NorthwindContext context)
        {
            context.Categories.AddOrUpdate(c => c.CategoryName,
                new Category {CategoryName = "Vehicles"},
                new Category {CategoryName = "Drinks"});

            context.Regions.AddOrUpdate(r => r.RegionID,
                new Region {RegionDescription = "Gomel", RegionID = 3});

            context.Territories.AddOrUpdate(t => t.TerritoryID,
                new Territory {TerritoryID = 199766, TerritoryDescription = "Railway station", RegionID = 3},
                new Territory {TerritoryID = 34324123, TerritoryDescription = "Independent square", RegionID = 3});
        }
    }
}
