using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesignPatterns.Factory
{
    public class FactoryApiClient
    {
        private static HttpClient client;

        static FactoryApiClient()
        {
            client = new HttpClient();
        }
    }
}
