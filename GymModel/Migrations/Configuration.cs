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
                    Name = "������",
                    BaiduInfo = string.Empty
                },
                new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "�ϳ���",
                    BaiduInfo = string.Empty
                },
                new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "�³���",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "��ɽ��",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "�ຼ��",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "ͩ®",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "�ٰ�",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "����",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "������",
                    BaiduInfo = string.Empty
                }, new Area()
                {
                    Id = Guid.NewGuid(),
                    Name = "ǧ����",
                    BaiduInfo = string.Empty
                });

        }
    }
}
