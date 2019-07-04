using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace DesignPatterns.Factory
{
    public class OrderSummaryFactory
    {
        private static XmlSerializer serializer;

        static OrderSummaryFactory()
        {
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "FactoryOrderSummary";
            serializer = new XmlSerializer(typeof(FactoryOrderSummary), xRoot);
        }

        public HttpContent BuildContent(FactoryOrderSummary orderSummary)
        {
            if (orderSummary.Vendor == Vendor.LawnChairCo)
            {
                string orderSummaryString;
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, orderSummary);
                    orderSummaryString = textWriter.ToString();
                }
                return new StringContent(orderSummaryString, Encoding.UTF8, "application/xml");
            }
            else
            {
                var orderSummaryString = JsonConvert.SerializeObject(orderSummary);
                return new StringContent(orderSummaryString, Encoding.UTF8, "application/json");
            }
        }
    }
}
