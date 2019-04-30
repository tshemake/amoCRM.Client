using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public interface IHttpSettings
    {
        string BaseUrl { get; set; }
        int TimeoutInMiliseconds { get; set; }
        Dictionary<string, string> AdditionalHeaders { get; set; }
        string UserAgent { get; set; }
    }

    public class HttpSettings : IHttpSettings
    {
        public string BaseUrl { get; set; }
        public int TimeoutInMiliseconds { get; set; } = 7000;
        public Dictionary<string, string> AdditionalHeaders { get; set; }
        public string UserAgent { get; set; }
    }
}
