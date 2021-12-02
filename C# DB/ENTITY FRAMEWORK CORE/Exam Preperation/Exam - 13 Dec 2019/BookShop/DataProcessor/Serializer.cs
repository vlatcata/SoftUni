using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks.Select(ab => new
                        {
                            BookName = ab.Book.Name,
                            BookPrice = ab.Book.Price.ToString("F2")
                        })
                        .OrderByDescending(b => b.BookPrice)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(b => b.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            ExportBooksDto[] books = context.Books
                .Where(b => b.PublishedOn <= date && b.Genre == Genre.Science)
                .Take(10)
                .Select(b => new ExportBooksDto()
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.Date)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBooksDto[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(new StringWriter(sb), books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}