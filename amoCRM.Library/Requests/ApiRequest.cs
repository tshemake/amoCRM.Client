using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Responses;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests
{
    public class ApiRequest
    {
        public Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>
        {
            { "Accept", "application/json;q=0.9,text/xml,application/xml,application/xhtml+xml;q=0.7" },
            { "Accept-Language", "en-us;q=0.8,en;q=0.5,ru-ru,ru;q=0.3" },
            { "Accept-Charset", "utf-8" },
        };
        public async Task<Response<TResult>> SendAsync<TResult>(HttpClient httpClient, string requestUri, Dictionary<string, string> nameValueCollection, Dictionary<string, string> moreHeaders)
            where TResult : class, new()
        {
            try
            {
                foreach (var header in _defaultHeaders)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                if (moreHeaders != null)
                {
                    foreach (var header in moreHeaders)
                    {
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage httpResponse;
                if (nameValueCollection != null && nameValueCollection.Keys.Any())
                {
                    var encodedContent = new FormUrlEncodedContent(nameValueCollection);
                    httpResponse = await httpClient.PostAsync(requestUri, encodedContent);
                }
                else
                {
                    httpResponse = await httpClient.GetAsync(requestUri);
                }

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<TResult>(json);
                        return new Response<TResult>(true, value, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), $"Service sent unknown content-type from url {requestUri}"));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<ResponseError>(json);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Moved)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<ResponseError>(json);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.PaymentRequired)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<ResponseError>(json);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<ResponseError>(json);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    if (httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        var value = FromJson<ResponseError>(json);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.BadGateway)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else
                {
                    var json = await httpResponse.Content.ReadAsStringAsync();
                    var value = FromJson<ResponseError>(json);
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                }
            }
            catch (Exception ex)
            {
                return new Response<TResult>(false, null, new ResultInfo(ex));
            }
        }

        private static T FromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
