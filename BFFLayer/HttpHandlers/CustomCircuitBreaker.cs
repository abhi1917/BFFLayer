using BFFLayer.Resources;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BFFLayer.HttpHandlers
{
    public static class CustomCircuitBreaker
    {
        public static AsyncRetryPolicy<HttpResponseMessage> CircuitBreaker= Policy
                                                                            .Handle<Exception>()
                                                                            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                                                                            .RetryAsync(CircuitBreakerResource.RetryCount);
    }
}