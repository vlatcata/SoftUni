using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeperator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null) : base("", ContentType.Html)
        {
            if (!viewName.Contains(PathSeperator))
            {
                viewName = controllerName + PathSeperator + viewName;
            }

            var viewPath = Path.GetFullPath($"./Views/" + viewName.TrimStart(PathSeperator) + ".cshtml");

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            Body = viewContent;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model.GetType()
                .GetProperties()
                .Select(x => new
                {
                    x.Name,
                    Value = x.GetValue(model)
                });

            foreach (var item in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{item.Name}{closingBrackets}", item.Value.ToString());
            }

            return viewContent;
        }
    }
}
