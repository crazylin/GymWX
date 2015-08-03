namespace GymModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymModel.GymContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GymModel.GymContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Areas.AddOrUpdate(a => a.Name,
                new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "西湖区",
                    BaiduInfo = string.Empty
                },
                new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "上城区",
                    BaiduInfo = string.Empty
                },
                new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "下城区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "江干区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "拱墅区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "滨江区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "萧山区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "余杭区",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "建德市",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "桐庐",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "淳安县",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "临安",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "富阳",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "富春江",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "千岛湖",
                    BaiduInfo = string.Empty
                });

        }
    }
}
