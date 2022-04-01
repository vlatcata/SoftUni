using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
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
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            List<User> users = new List<User>();
            List<Card> userCards = new List<Card>();

            foreach (ImportUserDto userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    //Problem is here, but there is no reason for it
                    continue;
                }

                User user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                bool areAllCardsValid = true;
                foreach (ImportCardDto cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        areAllCardsValid = false;
                        continue;
                    }

                    bool isCardTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out Object cardType);
                    if (!isCardTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        areAllCardsValid = false;
                        break;
                    }

                    Card card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = (CardType)cardType
                    };

                    userCards.Add(card);
                }

                if (!areAllCardsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                user.Cards = userCards;

                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), root);

            StringBuilder sb = new StringBuilder();

            using StringReader sr = new StringReader(xmlString);

            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])serializer.Deserialize(sr);

            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime date);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.PurchaseType, out object purchaseTypeObj);

                if (!isTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Game = game,
                    Card = card,
                    Date = date,
                    Type = (PurchaseType) purchaseTypeObj,
                    ProductKey = purchaseDto.Key
                };

                purchases.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, p.Game.Name, p.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
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