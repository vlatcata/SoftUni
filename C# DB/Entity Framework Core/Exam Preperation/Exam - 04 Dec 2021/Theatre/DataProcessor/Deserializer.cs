using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;
using Theatre = Theatre.Data.Models.Theatre;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlaysDto[]), new XmlRootAttribute("Plays"));

            using StringReader sw = new StringReader(xmlString);

            ImportPlaysDto[] playDtos = (ImportPlaysDto[])serializer.Deserialize(sw);

            List<Play> plays = new List<Play>();

            foreach (ImportPlaysDto playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan durationValue);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (durationValue.TotalHours <= 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(playDto.Genre, out Genre genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = durationValue,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine($"Successfully imported {play.Title} with genre {play.Genre} and a rating of {play.Rating}!");
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastsDto[]), new XmlRootAttribute("Casts"));

            using StringReader sw = new StringReader(xmlString);

            ImportCastsDto[] castDtos = (ImportCastsDto[])serializer.Deserialize(sw);

            List<Cast> casts = new List<Cast>();

            foreach (ImportCastsDto castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                string character = castDto.IsMainCharacter ? "main" : "lesser";

                casts.Add(cast);
                sb.AppendLine($"Successfully imported actor {cast.FullName} as a {character} character!");
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProjectionsDto[] projectionDtos = JsonConvert.DeserializeObject<ImportProjectionsDto[]>(jsonString);

            List<Data.Models.Theatre> theatres = new List<Data.Models.Theatre>();

            foreach (ImportProjectionsDto projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (projectionDto.Tickets.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Data.Models.Theatre theatre = new Data.Models.Theatre()
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = (sbyte)projectionDto.NumberOfHalls,
                    Director = projectionDto.Director
                };

                foreach (ImportTicketsDto ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);
                sb.AppendLine($"Successfully imported theatre {theatre.Name} with #{theatre.Tickets.Count} tickets!");

                context.Theatres.Add(theatre);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
