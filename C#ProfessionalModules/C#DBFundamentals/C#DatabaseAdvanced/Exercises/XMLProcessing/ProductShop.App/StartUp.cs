using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.App.Dtos;
using ProductShop.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(conf => conf.AddProfile<MapperConfigurationProfile>());
            var mapper = config.CreateMapper();

            using (var context = new ProductShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var importer = new Importer(mapper, context);

                importer.ImportUsers();
                importer.ImportProducts();
                importer.ImportCategories();
                importer.MapCategoriesToProducts();

                ExportProductsInRange(mapper, context);
                //It used to work but than i fucked up the dto names and changed stuff that i should'nt
                //ExportSoldProducts(mapper, context);
                ExportCategoriesPerProductCount(mapper, context);
                ExportUsersAndProducts(mapper, context);

                //Too tired to do the other one
            }
        }

        private static void ExportUsersAndProducts(IMapper mapper, ProductShopContext context)
        {
            var dtos = context.Users.Where(u => u.SoldProducts.Count >= 1)
                                    .OrderByDescending(u => u.SoldProducts.Count)
                                    .ThenBy(u => u.LastName)
                                    .Select(u => new UsersDto
                                    {
                                        Count = context.Users.Where(z => z.SoldProducts.Count >= 1).Count(),
                                        Users = context.Users.Where(k => k.SoldProducts.Count >= 1)
                                                       .OrderByDescending(k => k.SoldProducts.Count)
                                                       .ThenBy(k => k.LastName).Select(sp => new UserSoldProductDto
                                        {
                                            Age = sp.Age.ToString(),
                                            FirstName = sp.FirstName,
                                            LastName = sp.LastName,
                                            SoldProduct = new SecondSoldProductDto
                                            {
                                                Count = sp.SoldProducts.Count,
                                                Products = sp.SoldProducts.Select(bb => new SecondProductDto
                                                {
                                                    Name = bb.Name,
                                                    Price = bb.Price
                                                })
                                                .ToList()
                                            }
                                        }).ToList()
                                    }).ToList().First();

            string path = "../OutputXml/users-and-products.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(UsersDto),
                new XmlRootAttribute("users"));

            serializer.Serialize(new StreamWriter(path),
                                     dtos,
                                     new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }

        private static void ExportCategoriesPerProductCount(IMapper mapper, ProductShopContext context)
        {
            var dtos = context.Categories.Include(c => c.Products)
                                         .ThenInclude(p => p.Product)
                                         .OrderByDescending(c => c.Products.Count)
                                         .Select(c => mapper.Map<CategoriesPerProductCountDto>(c))
                                         .ToArray();

            string path = "../OutputXml/categories-by-products.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesPerProductCountDto[]),
                new XmlRootAttribute("categories"));

            serializer.Serialize(new StreamWriter(path),
                                 dtos,
                                 new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }

        private static void ExportSoldProducts(IMapper mapper, ProductShopContext context)
        {
            var dtos = context.Users.Include(u => u.SoldProducts)
                                    .Where(u => u.SoldProducts.Count >= 1)
                                    .OrderBy(u => u.LastName)
                                    .ThenBy(u => u.FirstName)
                                    .Select(u => mapper.Map<UserSoldProductDto>(u))
                                    .ToArray();

            string path = "../OutputXml/users-sold-products.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(UserSoldProductDto[]),
                new XmlRootAttribute("users"));

            serializer.Serialize(new StreamWriter(path),
                                 dtos,
                                 new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }

        private static void ExportProductsInRange(IMapper mapper, ProductShopContext context)
        {
            var dtos = context.Products.Include(p => p.Buyer)
                              .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                              .OrderBy(p => p.Price)
                              .Select(p => mapper.Map<ProductsInRangeDto>(p))
                              .ToArray();

            string path = "../OutputXml/products-in-range.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInRangeDto[]),
                new XmlRootAttribute("products"));

            serializer.Serialize(new StreamWriter(path),
                                 dtos,
                                  new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }


    }
}
