using DesignPatterns.Strategy;
using System;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        private static string listenUrl = "http://localhost:5000/api/listen";
        static async Task Main(string[] args)
        {
            await StrategyPattern();
        }

        public static async Task StrategyPattern()
        {
            var xmlBuilder = new OrderSummaryXmlRequestBuilder();
            var jsonBuilder = new OrderSummaryJsonRequestBuilder();

            var orderSummary = new OrderSummary
            {
                UserId = 1,
                ItemId = 20,
                PurchaseDate = DateTime.UtcNow
            };

            var xmlClient = new ApiClient(xmlBuilder);
            var xmlResponse = await xmlClient.SendOrderSummary(listenUrl, orderSummary);
            Console.WriteLine(xmlResponse);

            var jsonClient = new ApiClient(jsonBuilder);
            var jsonResponse = await jsonClient.SendOrderSummary(listenUrl, orderSummary);
            Console.WriteLine(jsonResponse);
            
        }
    }
}
