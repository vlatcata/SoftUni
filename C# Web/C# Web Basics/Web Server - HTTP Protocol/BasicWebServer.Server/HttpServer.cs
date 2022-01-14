﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAdress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAdress, int _port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAdress = IPAddress.Parse(_ipAdress);
            this.port = _port;

            this.serverListener = new TcpListener(ipAdress, port);

            routingTableConfiguration(routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {
            
        }

        public HttpServer(Action<IRoutingTable> routingTable) : this(8080, routingTable)
        {
            
        }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);

                var request = Request.Parse(requestText);
                var response = routingTable.MatchRequest(request);

                if (response.PreRenderAction != null)
                {
                    response.PreRenderAction(request, response);
                }

                WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
