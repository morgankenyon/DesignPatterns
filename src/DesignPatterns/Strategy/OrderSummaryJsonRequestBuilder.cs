using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesignPatterns.Strategy
{
    public class OrderSummaryJsonRequestBuilder : IOrderSummaryRequestBuilder
    {
        public HttpContent Build(OrderSummary orderSummary)
        {
            var orderSummaryString = JsonConvert.SerializeObject(orderSummary);
            return new StringContent(orderSummaryString, Encoding.UTF8, "application/json");
        }
    }
}
