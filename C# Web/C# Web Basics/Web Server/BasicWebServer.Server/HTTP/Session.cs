using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserid";

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            Id = id;
            data = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get => data[key];
            set => data[key] = value;
        }

        private Dictionary<string, string> data { get; set; }

        public string Id { get; init; }

        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        public void Clear()
        {
            data.Clear();
        }
    }
}
