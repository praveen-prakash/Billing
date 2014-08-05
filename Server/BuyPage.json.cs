using Starcounter;
using System;

[BuyPage_json]
partial class BuyPage : Page
{

}

[BuyPage_json.Offers]
partial class BuyPageOffers : Page
{
    void Handle(Input.Buy input)
    {
        var order = new Billing.Order();
        order.Offer = (Billing.Offer)this.Data;
        order.DateTime = DateTime.Now;
        Transaction.Commit();
    }
}
