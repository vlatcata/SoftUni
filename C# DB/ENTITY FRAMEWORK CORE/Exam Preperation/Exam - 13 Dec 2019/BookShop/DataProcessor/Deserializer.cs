using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));

            using StringReader sr = new StringReader(xmlString);

            ImportBookDto[] bookDtos = (ImportBookDto[])serializer.Deserialize(sr);

            List<Book> books = new List<Book>();

            foreach (ImportBookDto bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid =
                    DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookDate);
                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre) bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = bookDate
                };

                books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authorDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            List<Author> authors = new List<Author>();

            foreach (ImportAuthorDto authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isEmailValid = authors.FirstOrDefault(a => a.Email == authorDto.Email) != null;
                if (isEmailValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                foreach (ImportAuthorBookDto bookDto in authorDto.Books)
                {
                    var book = context.Books.Find(bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    AuthorBook ab = new AuthorBook()
                    {
                        Author = author,
                        BookId = bookDto.Id
                    };

                    author.AuthorsBooks.Add(ab);
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}