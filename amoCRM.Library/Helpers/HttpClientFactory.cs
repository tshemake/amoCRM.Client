using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace amoCRM.Library.Helpers
{
    public interface IHttpClientFactory
    {
        HttpClient GetClient(IHttpSettings settings);
    }

    public class HttpClientFactory : IHttpClientFactory, IDisposable
    {
        private readonly ConcurrentDictionary<string, HttpClient> _httpClients = new ConcurrentDictionary<string, HttpClient>();

        private static readonly Lazy<HttpClientFactory> _instance =
            new Lazy<HttpClientFactory>(() => new HttpClientFactory(), LazyThreadSafetyMode.ExecutionAndPublication);

        private HttpClientFactory()
        {
        }

        public static HttpClientFactory Instance
        {
            get => _instance.Value;
        }

        public HttpClient GetClient(IHttpSettings settings)
        {
            return _httpClients.GetOrAdd(
                    settings.BaseUrl,
                    client => CreateHttpClient(settings));
        }

        private HttpClient CreateHttpClient(IHttpSettings settings)
        {
            var handler = GetHandler();
            var httpClient = new HttpClient(handler) { BaseAddress = new Uri(settings.BaseUrl) };
            FillHttpClientProperty(httpClient, settings);

            return httpClient;
        }

        private HttpClientHandler GetHandler()
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer,
                UseCookies = true,
                UseDefaultCredentials = true,
                AllowAutoRedirect = false,
            };

            return handler;
        }

        private void FillHttpClientProperty(HttpClient httpClient, IHttpSettings settings)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            if (settings.AdditionalHeaders != null && settings.AdditionalHeaders.Any())
            {
                foreach (var header in settings.AdditionalHeaders)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            httpClient.Timeout = TimeSpan.FromMilliseconds(settings.TimeoutInMiliseconds);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(settings.UserAgent);
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _httpClients.Values.ToList().ForEach(httpClient =>
                {
                    try
                    {
                        httpClient.Dispose();
                    }
                    catch
                    {
                        // ignored
                    }
                });
            }

            _disposed = true;
        }
    }
}
