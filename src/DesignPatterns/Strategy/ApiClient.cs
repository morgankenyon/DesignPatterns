using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPatterns.Strategy
{
    public class ApiClient
    {
        private static HttpClient client;
        private static XmlSerializer serializer;

        static ApiClient()
        {
            client = new HttpClient();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "OrderSummary";
            serializer = new XmlSerializer(typeof(OrderSummary), xRoot);
        }

        public async Task<HttpStatusCode> SendOrderSummary(string uri, OrderSummary orderSummary)
        {
            string orderSummaryString;
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, orderSummary);
                orderSummaryString = textWriter.ToString();
            }

            var httpContent = new StringContent(orderSummaryString, Encoding.UTF8, "application/xml");
            var response = await client.PostAsync(uri, httpContent);
            return response.StatusCode;
        }
    }
}
