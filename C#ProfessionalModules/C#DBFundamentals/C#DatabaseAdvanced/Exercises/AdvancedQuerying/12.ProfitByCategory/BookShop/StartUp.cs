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

                //int input = int.Parse(Console.ReadLine());
                Console.WriteLine(GetTotalProfitByCategory(db));
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

            for (int i = 0; i < booksInfo.Count; i++)
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

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors.Where(a => EF.Functions.Like(a.FirstName, $"%{input}"))
                                              .Select(a => a.FirstName + " " + a.LastName)
                                              .OrderBy(a => a)
                                              .ToArray();

            return String.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] titles = context.Books.Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{input.ToLower()}%"))
                                           .Select(b => b.Title)
                                           .OrderBy(t => t)
                                           .ToArray();

            return String.Join(Environment.NewLine, titles);

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.Where(b => EF.Functions.Like(b.Author.LastName.ToLower(), $"{input.ToLower()}%"))
                                     .OrderBy(b => b.BookId)
                                     .Select(b => new { b.Title, AuthorName = b.Author.FirstName + " " + b.Author.LastName })
                                     .ToArray();

            string[] result = new string[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                result[i] = $"{books[i].Title} ({books[i].AuthorName})";
            }

            return String.Join(Environment.NewLine, result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books.Where(b => b.Title.Length > lengthCheck).Count();

            return count;

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Books.GroupBy(b => b.Author)
                                       .Select(g => new
                                       {
                                           AuthorName = g.Key.FirstName + " " + g.Key.LastName,
                                           Copies = g.Sum(b => b.Copies)
                                       })
                                       .OrderByDescending(a => a.Copies)
                                       .ToArray();

            string[] result = new string[authors.Length];
            for (int i = 0; i < authors.Length; i++)
            {
                result[i] = $"{authors[i].AuthorName} - {authors[i].Copies}";
            }

            return String.Join(Environment.NewLine, result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfits = context.Categories.Select(c => new
            {
                CategoryName = c.Name,
                TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
            })
                                                    .OrderByDescending(cp => cp.TotalProfit)
                                                    .ThenBy(cp => cp.CategoryName)
                                                    .ToArray();

            string[] result = new string[categoryProfits.Length];

            for (int i = 0; i < categoryProfits.Count(); i++)
            {
                result[i] = $"{categoryProfits[i].CategoryName} ${categoryProfits[i].TotalProfit:f2}";
            }

            return String.Join(Environment.NewLine, result);
        }
    }
}
