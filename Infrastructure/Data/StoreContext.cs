using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        /*
        在ASP.NET Core中，OnModelCreating是DbContext类的一个方法，用于在创建模型时配置数据模型的特定属性。
        在这个方法中，可以通过ModelBuilder对象来定义实体、关系和其他一些方面的属性。
        在这段代码中，重写了OnModelCreating方法，并调用了基类的OnModelCreating方法，
        以确保父类DbContext中的配置也能被应用。然后，通过调用ApplyConfigurationsFromAssembly方法，
        从当前执行程序集（即当前应用程序集）中加载实体类型的配置。这个方法需要一个Assembly对象作为参数，
        并自动查找实现IEntityTypeConfiguration<T>接口的类并应用它们的配置。
        总的来说，这段代码的作用是将当前应用程序集中所有实现了IEntityTypeConfiguration<T>接口的类中定义的模型配置应用到当前的DbContext中，
        以便实现对数据库模型的自动配置。
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p=>p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}