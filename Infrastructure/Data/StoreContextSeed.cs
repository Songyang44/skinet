using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entity;
using Core.Entity.OrderAggregate;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            /*
            在数据库中添加商品品牌数据。它首先检查数据库中是否已经存在商品品牌数据。如果不存在，它会从本地的JSON文件中读取数据，并使用JsonSerializer.Deserialize方法将数据反序列化为ProductBrand对象的列表。然后，它将这个列表添加到DbContext中，并使用SaveChanges方法将更改保存到数据库中。

            具体来说，代码的执行逻辑如下：

            使用Any()方法检查ProductBrands表中是否存在任何记录。如果表中没有任何记录，则执行以下操作：

            从位于 "../Infrastructure/Data/SeedData/brands.json" 的JSON文件中读取商品品牌数据。

            使用JsonSerializer.Deserialize方法将JSON数据反序列化为ProductBrand对象的列表。

            将ProductBrand列表添加到DbContext中。

            调用SaveChanges方法将更改保存到数据库中。

            这段代码通常在应用程序启动时执行，以确保数据库中始终存在必要的种子数据，例如商品品牌数据。
            */
            if(!context.ProductBrands.Any())
            {
                var brandsData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }

            if(!context.ProductTypes.Any())
            {
                var typesData=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if(!context.Product.Any())
            {
                var productsData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Product.AddRange(products);
            }

            if(!context.DeliveryMethods.Any())
            {
                var deliveryData=File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
            }


            /*
            这段代码主要的作用是在DbContext中检查是否有未保存的更改，如果有，则将更改保存到数据库中。

            具体来说，代码的执行逻辑如下：

            使用ChangeTracker.HasChanges()方法检查DbContext中是否有未保存的更改。如果有未保存的更改，则执行以下操作：

            调用SaveChangesAsync()方法将未保存的更改保存到数据库中。

            使用ChangeTracker.HasChanges()方法可以检测在DbContext中进行的更改是否有未保存的更改。
            如果有未保存的更改，则可以使用SaveChangesAsync()方法将这些更改保存到数据库中。
            这是一种常见的模式，可以确保在对数据库进行更改时始终保存最新的数据。
            此外，使用异步的SaveChangesAsync()方法可以确保数据库操作不会阻塞主线程，这是一种良好的编程实践。 
            */

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

        }
    }
}