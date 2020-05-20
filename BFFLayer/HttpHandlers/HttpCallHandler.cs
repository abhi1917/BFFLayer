using BFFLayer.Resources;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BFFLayer.HttpHandlers
{
    class HttpCallHandler:DelegatingHandler
    {
        private Dictionary<string, string> _headers;
        private Dictionary<string, string> _body;

        public HttpCallHandler(Dictionary<string,string> headers,Dictionary<string, string> body =null):base(new HttpClientHandler())
        {
            _headers = headers;
            _body = body;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
         HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request = PrepareRequest(request);
            Task<HttpResponseMessage> resp;
            if (CircuitBreakerResource.EnableCircuit)
            {
                resp = CustomCircuitBreaker.CircuitBreaker.ExecuteAsync(
                                                           () => base.SendAsync(request, cancellationToken));
            }
            else
            {
                resp = base.SendAsync(request, cancellationToken);
            }
            //resp.Wait();
            return resp.Result;
        }

        private HttpRequestMessage PrepareRequest(HttpRequestMessage request)
        {
            request = AddHeaders(request);
            request = AddBody(request);
            return request;
        }

        private HttpRequestMessage AddHeaders(HttpRequestMessage request)
        {
            foreach(var item in _headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }
            return request;
        }

        private HttpRequestMessage AddBody(HttpRequestMessage request)
        {
            if (null!=_body)
            {
                foreach(var item in _body)
                {
                    if (item.Key == ApiResource.GrantTypeKey)
                    {
                        request.Content = new FormUrlEncodedContent(_body);
                    }
                    else
                    {
                        request.Content = new StringContent(item.Value, Encoding.UTF8, item.Key);
                    }
                    break;
                }
            }
            return request;
        }

      
    }
}