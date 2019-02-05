namespace ProductShop.App
{
    using AutoMapper;
    using Newtonsoft.Json;

    using ProductShop.Data;

    using System;
    using System.IO;
    using System.Linq;

    public class Exporter
    {
        private ProductShopContext context;

        public Exporter(ProductShopContext context)
        {
            this.context = context;
        }

        public void ExportProductsInRange()
        {
            var products = this.context.Products
                                       .Where(p => p.Price >= 500 && p.Price <= 1000)
                                       .OrderBy(p => p.Price)
                                       .Select(p => new
                                       {
                                           name = p.Name,
                                           price = p.Price,
                                           //if FirstName is null -> LastName else FirstName + " " + LastName
                                           seller = (p.Seller.FirstName + " " ?? String.Empty) + p.Seller.LastName
                                       })
                                       .ToArray();

            string jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText(PathConfiguration.OutputProductsInRangePath, jsonString);
        }

        public void ExportSuccessfullySoldProducts()
        {
            var products = this.context.Users.Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                                             .OrderBy(u => u.LastName)
                                             .ThenBy(u => u.FirstName)
                                             .Select(u => new
                                             {
                                                 firstName = u.FirstName,
                                                 lastName = u.LastName,
                                                 soldProducts = u.ProductsSold
                                                                 .Where(sp => sp.Buyer != null)
                                                                 .Select(sp => new
                                                                 {
                                                                     name = sp.Name,
                                                                     price = sp.Price,
                                                                     buyerFirstName = sp.Buyer.FirstName,
                                                                     buyerLastName = sp.Buyer.LastName
                                                                 })
                                                                 .ToArray()
                                             })
                                             .ToArray();

            var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText(PathConfiguration.OutputSuccessfullySoldProductsPath, jsonString);
        }

        public void ExportCategoriesByProductCount()
        {
            var categories = this.context.Categories.OrderBy(c => c.CategoryProducts.Count)
                                         .Select(c => new
                                         {
                                             category = c.Name,
                                             productsCount = c.CategoryProducts.Count,
                                             averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                                             totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                                         })
                                         .ToArray();

            var jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText(PathConfiguration.OutputCategoriesByProductsCountPath, jsonString);
        }

        public void ExportUsersAndProducts()
        {
            var users = new
            {
                usersCount = this.context.Users.Where(u => u.ProductsSold.Count >= 1).Count(),
                users = this.context.Users.Where(u => u.ProductsSold.Count >= 1)
                                          .OrderByDescending(u => u.ProductsSold.Count)
                                          .ThenBy(u => u.LastName)
                                          .Select(u => new
                                          {
                                              firtsName = u.FirstName,
                                              lastName = u.LastName,
                                              age = u.Age,
                                              soldProducts = new
                                              {
                                                  count = u.ProductsSold.Count,
                                                  products = u.ProductsSold.Select(ps => new
                                                  {
                                                      name = ps.Name,
                                                      price = ps.Price
                                                  })
                                                  .ToArray()
                                              }
                                          })
                                          .ToArray()
            };

            var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText(PathConfiguration.OutputUsersAndProductsPath, jsonString);
        }
    }
}
