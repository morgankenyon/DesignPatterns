using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace DesignPatterns.Strategy
{
    public class OrderSummaryXmlRequestBuilder : IOrderSummaryRequestBuilder
    {
        private static XmlSerializer serializer;

        static OrderSummaryXmlRequestBuilder()
        {
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "OrderSummary";
            serializer = new XmlSerializer(typeof(OrderSummary), xRoot);
        }

        public HttpContent Build(OrderSummary orderSummary)
        {
            string orderSummaryString;
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, orderSummary);
                orderSummaryString = textWriter.ToString();
            }

            return new StringContent(orderSummaryString, Encoding.UTF8, "application/xml");
        }
    }
}
