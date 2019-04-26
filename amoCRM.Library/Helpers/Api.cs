using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace amoCRM.Library.Helpers
{
    public class Api
    {
        public Api() { }

        public string Get(QueryParameter param)
        {
            try
            {
                var query = new StringBuilder();
                var headers = new Dictionary<string, string>();
                if (param.Ids != null)
                {
                    query.Append('?');
                    var idParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, List<int>, ParameterAttribute, string>(prop => prop.Ids, attr => attr.Name);
                    foreach (var idParamValue in param.Ids)
                    {
                        query.Append($"{idParamName}[]={idParamValue}&");
                    }
                    var limitParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, int?, ParameterAttribute, string>(prop => prop.Limit, attr => attr.Name);
                    query.Append($"{limitParamName}={param.Ids.Count}");
                }
                else
                {
                    var since = new DateTime(1970, 1, 1);
                    if (param.Since.HasValue)
                    {
                        since = param.Since.Value;
                    }
                    var sinceParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, DateTime?, ParameterAttribute, string>(prop => prop.Since, attr => attr.Name);
                    var sinceParamValue = since.ToString("ddd, dd MMM yyyy HH:mm:ss 'UTC'", new CultureInfo("en-US"));
                    if (headers.ContainsKey(sinceParamName))
                    {
                        headers[sinceParamName] = sinceParamValue;
                    }
                    else
                    {
                        headers.Add(sinceParamName, sinceParamValue);
                    }

                    var limitParamValue = 100;
                    if (param.Limit.HasValue)
                    {
                        limitParamValue = param.Limit.Value;
                    }
                    var limitParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, int?, ParameterAttribute, string>(prop => prop.Limit, attr => attr.Name);
                    query.Append($"?{limitParamName}={limitParamValue}");

                    var offsetParamValue = 0;
                    if (param.Offset.HasValue)
                    {
                        offsetParamValue = param.Offset.Value;
                    }
                    var offsetParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, int?, ParameterAttribute, string>(prop => prop.Offset, attr => attr.Name);
                    query.Append($"&{offsetParamName}={offsetParamValue}");

                    if (string.IsNullOrWhiteSpace(param.Query))
                    {
                        var queryParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, string, ParameterAttribute, string>(prop => prop.Query, attr => attr.Name);
                        var queryParamValue = StripHtml(param.Query);
                        query.Append($"&{queryParamName}={queryParamValue}");
                    }

                    if (param.Queries != null)
                    {
                        foreach (var keyValueQueryPair in param.Queries)
                        {
                            if (keyValueQueryPair.Value == null || !keyValueQueryPair.Value.Any())
                            {
                                continue;
                            }
                            else if (keyValueQueryPair.Value.Count == 1)
                            {
                                var queryParamName = keyValueQueryPair.Key;
                                var queryParamValue = keyValueQueryPair.Value.First();
                                query.Append($"&{queryParamName}={queryParamValue}");
                            }
                            else if (keyValueQueryPair.Value.Count > 1)
                            {
                                foreach (var queryParamValue in keyValueQueryPair.Value)
                                {
                                    var queryParamName = keyValueQueryPair.Key;
                                    query.Append($"&{queryParamName}[]={queryParamValue}");
                                }
                            }
                        }
                    }

                    if (param.ModelType == ModelType.Task || param.ModelType == ModelType.Note)
                    {
                        if (param.ModelType == ModelType.Note && param.Type == ModelType.Unknown)
                        {
                            throw new Exception($"Parameters type require for {param.ModelType}");
                        }

                        if (param.Type != ModelType.Unknown)
                        {
                            var typeParamValue = ModelType.Contact.GetStringValue();
                            if (param.Type != ModelType.Contact)
                            {
                                typeParamValue = ModelType.Lead.GetStringValue();
                            }
                            var typeParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, ModelType, ParameterAttribute, string>(prop => prop.Type, attr => attr.Name);
                            query.Append($"&{typeParamName}={typeParamValue}");
                        }

                        if (param.ElementId.HasValue)
                        {
                            var elementIdParamName = AttributeHelper.GetPropertyAttributeValue<QueryParameter, int?, ParameterAttribute, string>(prop => prop.ElementId, attr => attr.Name);
                            var elementIdParamValue = param.ElementId.Value;
                            query.Append($"&{elementIdParamName}={elementIdParamValue}");
                        }
                    }
                }
                return query.ToString();
            }
            catch
            {
                return null;
            }
        }

        private static string StripHtml(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = Regex.Replace(input, @"<[^>]+>|&nbsp;", string.Empty);
            input = input.Trim();
            return input;
        }
    }
}
