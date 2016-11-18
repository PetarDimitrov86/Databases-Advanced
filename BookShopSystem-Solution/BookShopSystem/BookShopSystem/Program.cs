namespace BookShopSystem.Client
{
    using System;
    using System.Linq;
    using Data;
    using BookShopSytem.Models;

    class Program
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();

            PrintBooksAfter2000(context);
            PrintAuthorsWithBookBefore1990(context);
            AuthorsSortedByNumberOfBooks(context);
            PrintBooksByGivenAuthor(context);
            GetCategoriesAnd3BooksOfEach(context);

            // var books = context.Books
            //                     .Take(3)
            //                     .ToList();
            // books[0].RelatedBooks.Add(books[1]);
            // books[1].RelatedBooks.Add(books[0]);
            // books[0].RelatedBooks.Add(books[2]);
            // books[2].RelatedBooks.Add(books[0]);

            // context.SaveChanges();

            var booksFromQuery = context.Books.Take(3);

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }

        private static void GetCategoriesAnd3BooksOfEach(BookShopContext context)
        {
            var categories = context.Categories.OrderBy(category => category.Books.Count).Select(category => new
            {
                category.Name,
                BooksCount = category.Books.Count,
                Books = category.Books.OrderByDescending(book => book.ReleaseDate).Take(3).Select(book => new
                {
                    book.Title,
                    book.ReleaseDate
                })
            });

            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.Name}: {category.BooksCount} books");
                foreach (var book in category.Books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate})");
                }
            }
        }

        private static void PrintBooksByGivenAuthor(BookShopContext context)
        {
            var books =
                context.Books.Where(book => book.Author.FirstName == "George" && book.Author.LastName == "Powell")
                    .OrderByDescending(book => book.ReleaseDate)
                    .ThenBy(book => book.Title);
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Title} {book.ReleaseDate} {book.Copies}");
            }
        }

        private static void AuthorsSortedByNumberOfBooks(BookShopContext context)
        {
            var authors = context.Authors.OrderByDescending(author => author.Books.Count);

            foreach (Author author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Count}");
            }
        }

        private static void PrintAuthorsWithBookBefore1990(BookShopContext context)
        {
            var authors =
                context.Authors.Where(
                    author =>
                        author.Books.Count(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year < 1990) != 0);

            foreach (Author author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        private static void PrintBooksAfter2000(BookShopContext context)
        {
            var wantedBooks = context.Books.Where(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year > 2000);
            foreach (Book wantedBook in wantedBooks)
            {
                Console.WriteLine(wantedBook.Title);
            }
        }
    }
}
