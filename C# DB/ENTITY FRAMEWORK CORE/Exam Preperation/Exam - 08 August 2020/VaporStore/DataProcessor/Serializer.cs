using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
			var genre = context.Genres
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    TotalPlayers = g.Games.Sum(g => g.Purchases.Count),
                    Games = g.Games.Where(g => g.Purchases.Any())
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = String.Join(", ", g.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(p => p.Players)
                        .ThenBy(g => g.Id)
                        .ToArray()
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            string result = JsonConvert.SerializeObject(genre, Formatting.Indented);

			return result;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);

            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .OrderBy(p => p.Date)
                        .Select(p => new ExportUserPurchaseDto()
                        {
                            Card = p.Card.Number,
                            CVC = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto()
                            {
                                Name = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            serializer.Serialize(sw, users, namespaces);

            return sb.ToString().TrimEnd();
        }
	}
}