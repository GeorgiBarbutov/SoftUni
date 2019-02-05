namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                Console.WriteLine(GetGoldenBooks(db));
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] bookTitles = context.Books
                                         .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                                         .OrderBy(b => b.BookId)
                                         .Select(b => b.Title)
                                         .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }
    }
}
