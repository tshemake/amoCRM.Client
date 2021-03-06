﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Helpers;
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
        public async Task<Response<TResult>> SendAsync<TResult>(HttpClient httpClient, string requestUri, HttpContent content, Dictionary<string, string> moreHeaders)
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
                if (content != null)
                {
                    httpResponse = await httpClient.PostAsync(requestUri, content);
                }
                else
                {
                    httpResponse = await httpClient.GetAsync(requestUri);
                }

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<TResult>(httpResponse);
                        return new Response<TResult>(true, value, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), $"Service sent unknown content-type from url {requestUri}"));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
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
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.PaymentRequired)
                {
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
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
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
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
                    if (IsJsonContentType(httpResponse))
                    {
                        var value = await ReadContentAsJsonAsync<ResponseError>(httpResponse);
                        return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode), value.Error.Code));
                    }
                    return new Response<TResult>(false, null, new ResultInfo(HttpStatusCodeList.GetByCode(httpResponse.StatusCode)));
                }
            }
            catch (Exception ex)
            {
                return new Response<TResult>(false, null, new ResultInfo(ex));
            }
        }

        private static async Task<TResult> ReadContentAsJsonAsync<TResult>(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();
            return EntityEx.GetAs<TResult>(content);
        }

        private static bool IsJsonContentType(HttpResponseMessage httpResponse)
        {
            return httpResponse.Content.Headers.ContentType.MediaType == "application/json" ||
                httpResponse.Content.Headers.ContentType.MediaType == "application/hal+json";
        }
    }
}
