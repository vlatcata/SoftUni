﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BasicWebServer.Server.Routing;

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

        public static IRoutingTable MapControllers(this IRoutingTable routingTable)
        {
            IEnumerable<MethodInfo> controllerActions = GetControllerActions();

            foreach (var controllerAction in controllerActions)
            {
                string controllerName = controllerAction
                    .DeclaringType
                    .Name
                    .Replace(nameof(Controller), string.Empty);

                string actionName = controllerAction.Name;
                string path = $"/{controllerName}/{actionName}";

                var responseFunction = GetResponseFunction(controllerAction);

                Method httpMethod = Method.Get;
                var actionMethodAttribute = controllerAction
                    .GetCustomAttribute<HttpMethodAttribute>();

                if (actionMethodAttribute != null)
                {
                    httpMethod = actionMethodAttribute.HttpMethod;
                }

                routingTable.Map(httpMethod, path, responseFunction);

                MapDefaultRoutes(
                    routingTable,
                    httpMethod,
                    controllerName,
                    actionName,
                    responseFunction);
            }

            return routingTable;
        }

        private static void MapDefaultRoutes(IRoutingTable routingTable, Method httpMethod, string controllerName, string actionName, Func<Request, Response> responseFunction)
        {
            const string defaultActionName = "Index";
            const string defaultControllerName = "Home";

            if (actionName == defaultActionName)
            {
                routingTable.Map(httpMethod, $"/{controllerName}", responseFunction);

                if (controllerName == defaultControllerName)
                {
                    routingTable.Map(httpMethod, "/", responseFunction);
                }
            }
        }

        private static Func<Request, Response> GetResponseFunction(MethodInfo controllerAction)
        {
            return request =>
            {
                var controllerInstance = CreateController(controllerAction.DeclaringType, request);
                var parameterValues = GetParameterValues(controllerAction, request);

                return (Response)controllerAction.Invoke(controllerInstance, parameterValues);
            };
        }

        private static object[] GetParameterValues(MethodInfo controllerAction, Request request)
        {
            var actionParameters = controllerAction
                .GetParameters()
                .Select(p => new
                {
                    p.Name,
                    p.ParameterType
                })
                .ToArray();

            var parameterValues = new object[actionParameters.Length];

            for (int i = 0; i < actionParameters.Length; i++)
            {
                var parameter = actionParameters[i];

                if (parameter.ParameterType.IsPrimitive ||
                    parameter.ParameterType == typeof(string))
                {
                    string parameterValue = request.GetValue(parameter.Name);
                    parameterValues[i] = Convert.ChangeType(parameterValue, parameter.ParameterType);
                }
                else
                {
                    var parameterValue = Activator.CreateInstance(parameter.ParameterType);
                    var parameterProperties = parameter.ParameterType.GetProperties();

                    foreach (var property in parameterProperties)
                    {
                        var propertyValue = request.GetValue(property.Name);
                        property.SetValue(
                            parameterValue,
                            Convert.ChangeType(propertyValue, property.PropertyType));
                    }

                    parameterValues[i] = parameterValue;
                }
            }

            return parameterValues;
        }

        private static IEnumerable<MethodInfo> GetControllerActions()
            => Assembly
            .GetEntryAssembly()
            .GetExportedTypes()
            .Where(t => t.IsAbstract == false)
            .Where(t => t.IsAssignableTo(typeof(Controller)))
            .Where(t => t.Name.EndsWith(nameof(Controller)))
            .SelectMany(t => t
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.ReturnType.IsAssignableTo(typeof(Response)))
            ).ToList();

        private static string GetValue(this Request request, string name)
            => request.Query.GetValueOrDefault(name) ??
            request.Form.GetValueOrDefault(name);
    }
}
