using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class FactoryApiClient
    {
        private static HttpClient client;
        private OrderSummaryFactory factory;

        static FactoryApiClient()
        {
            client = new HttpClient();
        }

        public FactoryApiClient(OrderSummaryFactory factory)
        {
            this.factory = factory;
        }

        public async Task<HttpStatusCode> SendOrderSummary(string uri, FactoryOrderSummary orderSummary)
        {
            var httpContent = factory.BuildContent(orderSummary);
            var response = await client.PostAsync(uri, httpContent);
            return response.StatusCode;
        }
    }
}
