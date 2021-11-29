using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (ImportGameDto gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
					continue;
                }

                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InstalledUICulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game g = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer dev = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (dev == null)
                {
                    Developer developer = new Developer()
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);

                    g.Developer = developer;
                }
                else
                {
                    g.Developer = dev;
                }

                Genre ge = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (ge == null)
                {
                    Genre genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);

                    g.Genre = genre;
                }
                else
                {
                    g.Genre = ge;
                }

                foreach (string tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag gameTag = tags.FirstOrDefault(t => t.Name == tagName);

                    if (gameTag == null)
                    {
                        Tag gt = new Tag()
                        {
                            Name = tagName
                        };

                        tags.Add(gt);

                        g.GameTags.Add( new GameTag()
                        {
                            Game = g,
                            Tag = gt
                        });
                    }
                    else
                    {
                        g.GameTags.Add(new GameTag()
                        {
                            Game = g,
                            Tag = gameTag
                        });
                    }
                }

                if (g.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(g);
                sb.AppendLine(String.Format(SuccessfullyImportedGame, g.Name, g.Genre.Name, g.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}