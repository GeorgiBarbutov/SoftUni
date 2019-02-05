namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                string input = Console.ReadLine();
                Console.WriteLine(GetBooksReleasedBefore(db, input));
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

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] bookTitles = context.Books
                                         .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                                         .OrderBy(b => b.BookId)
                                         .Select(b => b.Title)
                                         .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksInfo = context.Books
                                   .Where(b => b.Price > 40.0m)
                                   .OrderByDescending(b => b.Price)
                                   .Select(b => new { Title = b.Title, Price = b.Price })
                                   .ToList();

            string[] result = new string[booksInfo.Count];

            for(int i = 0; i< booksInfo.Count; i++)
            {
                result[i] = $"{booksInfo[i].Title} - ${booksInfo[i].Price:f2}";
            }

            return String.Join(Environment.NewLine, result);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context.Books
                                         .Where(b => b.ReleaseDate.Value.Year != year)
                                         .OrderBy(b => b.BookId)
                                         .Select(b => b.Title)
                                         .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

            string[] bookTitles = context.Books
                                         .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                                         .OrderBy(b => b.Title)
                                         .Select(b => b.Title)
                                         .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            int day = int.Parse(date.Split('-')[0]);
            int mounth = int.Parse(date.Split('-')[1]);
            int year = int.Parse(date.Split('-')[2]);

            var books = context.Books.Where(b => b.ReleaseDate < new DateTime(year, mounth, day))
                                     .OrderByDescending(b => b.ReleaseDate)
                                     .Select(b => new { b.Title, b.EditionType, b.Price })
                                     .ToArray();

            string[] result = new string[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                result[i] = $"{books[i].Title} - {books[i].EditionType} - ${books[i].Price:f2}";
            }

            return String.Join(Environment.NewLine, result);
        }
    }
}
