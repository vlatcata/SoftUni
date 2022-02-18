namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using Sms.Data.Common;
    using SMS.Contracts;
    using SMS.Services;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());


            server.ServiceCollection
                .Add<IRepository, Repository>()
                .Add<IValidationService, ValidationService>()
                .Add<IUserService, UserService>()
                .Add<IProductService, ProductService>()
                .Add<ICartService, CartService>();

            await server.Start();
        }
    }
}