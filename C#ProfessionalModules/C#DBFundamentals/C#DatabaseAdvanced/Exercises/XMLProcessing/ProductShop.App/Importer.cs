using AutoMapper;
using ProductShop.App.Dtos;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop.App
{
    public class Importer
    {
        private IMapper mapper;
        private ProductShopContext context;

        public Importer(IMapper mapper, ProductShopContext context)
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
            XmlRootAttribute categoriesRootAttribute = new XmlRootAttribute("categories");
            string categoriesPath = "../Xml/categories.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), categoriesRootAttribute);

            var categoryDtos = (CategoryDto[])serializer.Deserialize(new StreamReader(categoriesPath));
            var categories = new List<Category>();

            foreach (var dto in categoryDtos)
            {
                if (IsValid(dto))
                {
                    var category = this.mapper.Map<Category>(dto);

                    categories.Add(category);
                }
            }

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();
        }

        public void ImportProducts()
        {
            XmlRootAttribute productRootAttribute = new XmlRootAttribute("products");
            string productsPath = "../Xml/products.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ProductDto[]), productRootAttribute);

            var productDtos = (ProductDto[])serializer.Deserialize(new StreamReader(productsPath));

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
                    productDtos[i].BuyerId = randomInt.ToString();
                }
                productDtos[i].SellerId = random.Next(1, count);
            }

            var products = new List<Product>();

            foreach (var dto in productDtos)
            {
                if (IsValid(dto))
                {
                    var product = this.mapper.Map<Product>(dto);

                    products.Add(product);
                }
            }

            this.context.Products.AddRange(products);
            this.context.SaveChanges();
        }

        public void ImportUsers()
        {
            XmlRootAttribute usersRootAttribute = new XmlRootAttribute("users");
            string usersPath = "../Xml/users.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), usersRootAttribute);

            var userDtos = (UserDto[])serializer.Deserialize(new StreamReader(usersPath));
            var users = new List<User>();

            foreach (var dto in userDtos)
            {
                if (IsValid(dto))
                {
                    var user = this.mapper.Map<User>(dto);

                    users.Add(user);
                }
            }

            this.context.Users.AddRange(users);
            this.context.SaveChanges();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
