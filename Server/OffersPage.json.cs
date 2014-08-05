using Starcounter;

[OffersPage_json]
partial class OffersPage : Page
{
    void Handle(Input.Add input)
    {
        var offer = new Billing.Offer();
        Transaction.Commit();

        var page = new OffersPageOffers()
        {
            Data = offer
        };
        Offers.Add(page);
    }
}

[OffersPage_json.Offers]
partial class OffersPageOffers : Page
{
    void Handle(Input.Name input)
    {
        Name = input.Value;
        Transaction.Commit();
    }

    void Handle(Input.Price input)
    {
        Price = input.Value;
        Transaction.Commit();
    }

    void Handle(Input.Remove input)
    {
        Data.Delete();
        Transaction.Commit();
        ((Starcounter.Arr<OffersPageOffers>)this.Parent).Remove(this);
    }
}
