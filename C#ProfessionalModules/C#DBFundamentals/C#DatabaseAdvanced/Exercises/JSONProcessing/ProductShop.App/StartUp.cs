namespace ProductShop.App
{
    using AutoMapper;

    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            // !!! Change server in Configuration.ConnectonString before running !!! 
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Import(context, mapper);
            Export(context);
        }

        private static void Export(ProductShopContext context)
        {
            var exporter = new Exporter(context);

            exporter.ExportProductsInRange();
            exporter.ExportSuccessfullySoldProducts();
            exporter.ExportCategoriesByProductCount();
            exporter.ExportUsersAndProducts();
        }

        private static void Import(ProductShopContext context, IMapper mapper)
        {
            var importer = new Importer(context, mapper);

            importer.ImportUsers();
            importer.ImportProducts();
            importer.ImportCategories();
            importer.MapCategoriesToProducts();
        }
    }
}
