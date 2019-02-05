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

                string command = Console.ReadLine();
                string result = GetBooksByAgeRestriction(db, command);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string[] bookTitles = context.Books
                                         .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                                         .OrderBy(b => b.Title)
                                         .Select(b => b.Title)
                                         .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }
    }
}
