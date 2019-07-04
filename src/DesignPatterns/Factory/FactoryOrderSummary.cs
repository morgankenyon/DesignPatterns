using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory
{
    public class FactoryOrderSummary
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Name { get; set; }
    }

    public enum Vendor
    {
        LawnChairCo,
        MagicCubeInc,
        BestComputersInc
    }
}
