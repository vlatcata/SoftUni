﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection :IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            this.headers = new Dictionary<string, Header>();
        }

        public int Count => this.headers.Count;

        public void Add(string name, string value)
        {
            var header = new Header(name, value);
            this.headers.Add(name, header);
        }

        public IEnumerator<Header> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
