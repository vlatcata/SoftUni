using System.Linq;
using System.Text;

namespace MusicHub
{
    using Data;
    using Initializer;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here

            Console.WriteLine(ExportAlbumsInfo(context, 9));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsByproducer = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    TotalPrice = a.Price.ToString("00"),
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = a.Price.ToString("00"),
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                    .ToList()
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToList();

            foreach (var a in albumsByproducer)
            {
                var songCount = 0;

                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                foreach (var s in a.AlbumSongs)
                {
                    songCount++;

                    sb.AppendLine($"---#{songCount}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {a.TotalPrice}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
