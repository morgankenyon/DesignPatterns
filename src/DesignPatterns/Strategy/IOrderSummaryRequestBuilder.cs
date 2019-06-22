using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesignPatterns.Strategy
{
    public interface IOrderSummaryRequestBuilder
    {
        HttpContent Build(OrderSummary orderSummary);
    }
}
