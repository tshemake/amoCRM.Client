using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public class RequestGetIncomingLeads : Request<ReadOnlyCollection<IncomingLead>>
    {
        public RequestGetIncomingLeads(HttpClient httpClient)
        {
            RequestUri = ApiConstants.API_GET_INCOMING_LEADS;
            RequestType = RequestType.IncomingLead;
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<IncomingLead>>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<IncomingLead>>(response.Succeeded, response.Result, response.Info);
        }

        public override Response<ReadOnlyCollection<IncomingLead>> ProcessResponse(Response<ApiResponse<ReadOnlyCollection<IncomingLead>>> response)
        {
            Response<ReadOnlyCollection<IncomingLead>> result;
            if (response.Succeeded)
            {
                if (response.Result.Embedded == null)
                {
                    response.Result.Embedded = new Embedded<ReadOnlyCollection<IncomingLead>>
                    {
                        Items = new List<IncomingLead>().AsReadOnly()
                    };
                }
                result = new Response<ReadOnlyCollection<IncomingLead>>(response.Succeeded, response.Result.Embedded.Items, response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<IncomingLead>>(response.Succeeded, null, response.Info);
            }
            return result;
        }
    }
}
