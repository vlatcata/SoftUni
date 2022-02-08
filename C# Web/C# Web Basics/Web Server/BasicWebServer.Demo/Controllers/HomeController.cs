﻿using BasicWebServer.Demo.Models;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.HTTP;
using System.Text;
using System.Web;

namespace BasicWebServer.Server.Controllers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(Request request) : base(request)
        {
        }

        [HttpGet]
        public Response Index() => Text("Hello from the server!");

        public Response Student(string name, int age) => Text($"Hello, I am {name}, {age} years old.");

        public Response Redirect() => Redirect("https://softuni.org");

        public Response Html() => View();

        [HttpPost]
        public Response HtmlFormPost()
        {
            var name = Request.Form["Name"];
            var age = Request.Form["Age"];

            var model = new FormViewModel
            {
                Name = name,
                Age = int.Parse(age)
            };

            return View(model);
        }

        public Response Content() => View();

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName, new string[] { "https://judge.softuni.org", "https://softuni.org"}).Wait();

            return File(FileName);
        }

        public Response Cookies()
        {

            if (Request.Cookies.Any(c => c.Name != Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");

                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();

            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";
            var sessionExists = Request.Session.ContainsKey(currentDateKey);

            if (sessionExists)
            {
                var currentDate = Request.Session[currentDateKey];
                return Text($"Stored date: {currentDate}");
            }

            return Text("Current date stored!");
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new String('-', 100), responses);

            //await File.WriteAllTextAsync(fileName, responsesString);
        }
    }
}
