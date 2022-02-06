﻿using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System.Reflection;

namespace BasicWebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable, string path, Func<TController, Response> controllerFunction) where TController : Controller
            => routingTable.MapGet(path, request => controllerFunction(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, Response> controllerFunction) where TController : Controller
            => routingTable.MapPost(path, request => controllerFunction(CreateController<TController>(request)));

        private static TController CreateController<TController>(Request request)
            => (TController)Activator.CreateInstance(typeof(TController), new[] { request });

        private static Controller CreateController(Type controllerType, Request request)
        {
            var controller = (Controller)Request.ServiceCollection.CreateInstance(controllerType);

            controllerType.GetProperty("Request", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(controller, request);

            return controller;
        }
    }
}
