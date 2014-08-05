using Starcounter;
using System;

namespace Billing
{
    [Database]
    public class Vendable
    {
        public string Name;
    }

    [Database]
    public class Offer
    {
        public string Name;
        public decimal Price;
    }

    [Database]
    public class OfferItem
    {
        public Offer Offer;
        public Vendable Vendable;
    }

    [Database]
    public class Order
    {
        public Offer Offer;
        public DateTime DateTime;
        public Receipt Receipt;
    }

    [Database]
    public class Receipt
    {
        public DateTime DateTime;
    }
}
