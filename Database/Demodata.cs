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
        public QueryResultRows<OfferItem> OfferItems { get { return Db.SQL<OfferItem>("SELECT o FROM Billing.OfferItem o WHERE Offer=?", this); } }
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
        public Invoice Invoice;
    }

    [Database]
    public class Invoice
    {
        public DateTime DateTime;
        public Decimal TotalPrice;
        public QueryResultRows<Order> Orders { get { return Db.SQL<Order>("SELECT o FROM \"Billing.Order\" o WHERE Invoice=?", this); } }
    }
}
