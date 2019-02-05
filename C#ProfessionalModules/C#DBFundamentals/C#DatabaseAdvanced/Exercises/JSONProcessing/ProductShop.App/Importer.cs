namespace ProductShop.App
{
    using AutoMapper;
    using Newtonsoft.Json;

    using Dto.ImportDtos;
    using ProductShop.Data;
    using ProductShop.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    public class Importer
    {
        private ProductShopContext context;
        private IMapper mapper;

        public Importer(ProductShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void MapCategoriesToProducts()
        {
            var products = this.context.Products.ToArray();
            var categories = this.context.Categories.ToArray();

            Random random = new Random();
            List<CategoryProduct> categoryProductToAdd = new List<CategoryProduct>();

            foreach (var product in products)
            {
                var categoryProduct = new CategoryProduct()
                {
                    ProductId = product.Id,
                    CategoryId = categories[random.Next(0, categories.Length)].Id
                };

                categoryProductToAdd.Add(categoryProduct);
            }

            this.context.CategoryProducts.AddRange(categoryProductToAdd);
            this.context.SaveChanges();
        }

        public void ImportCategories()
        {
            var categoryDtos = JsonConvert.DeserializeObject<CategoryDto[]>(File.ReadAllText(PathConfiguration.InputCategoriesPath));

            var categoriesToAdd = new List<Category>();

            foreach (var dto in categoryDtos)
            {
                if(IsValid(dto))
                {
                    categoriesToAdd.Add(this.mapper.Map<Category>(dto));
                }
            }

            this.context.Categories.AddRange(categoriesToAdd);
            this.context.SaveChanges();
        }

        public void ImportProducts()
        {
            var productDtos = JsonConvert.DeserializeObject<ProductDto[]>(File.ReadAllText(PathConfiguration.InputProductsPath));

            int count = this.context.Users.Count();
            Random random = new Random();

            for (int i = 0; i < productDtos.Length; i++)
            {
                int randomInt = random.Next(1, count + 10);

                if (randomInt > count)
                {
                    productDtos[i].BuyerId = null;
                }
                else
                {
                    productDtos[i].BuyerId = randomInt;
                }
                productDtos[i].SellerId = random.Next(1, count);
            }

            var productsToAdd = new List<Product>();

            foreach (var dto in productDtos)
            {
                if (IsValid(dto))
                {
                    productsToAdd.Add(this.mapper.Map<Product>(dto));
                }
            }

            this.context.Products.AddRange(productsToAdd);
            this.context.SaveChanges();
        }

        public void ImportUsers()
        {
            var userDtos = JsonConvert.DeserializeObject<UserDto[]>(File.ReadAllText(PathConfiguration.InputUsersPath));

            var usersToAdd = new List<User>();

            foreach (var dto in userDtos)
            {
                if(IsValid(dto))
                {
                    usersToAdd.Add(this.mapper.Map<User>(dto));
                }
            }

            this.context.Users.AddRange(usersToAdd);
            this.context.SaveChanges();
        }

        private bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
