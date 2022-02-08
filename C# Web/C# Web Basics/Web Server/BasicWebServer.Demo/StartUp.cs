using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;

public class StartUp
{
    public static async Task Main()
    {
        var server = new HttpServer(routes => routes
        .MapControllers());

        await server.Start();
    }
}
