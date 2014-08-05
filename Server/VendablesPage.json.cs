using Starcounter;

[VentablesPage_json]
partial class VentablesPage : Page
{
    void Handle(Input.Add input)
    {
        var vendable = new Billing.Vendable();
        Transaction.Commit();

        var page = new VentablesPageVendables()
        {
            Data = vendable
        };
        Vendables.Add(page);
    }
}

[VentablesPage_json.Vendables]
partial class VentablesPageVendables : Page/*, IBound<Billing.Vendable>*/
{
    void Handle(Input.Name input)
    {
        Name = input.Value;
        Transaction.Commit();
    }

    void Handle(Input.Remove input)
    {
        Data.Delete();
        Transaction.Commit();
        ((Starcounter.Arr<VentablesPageVendables>)this.Parent).Remove(this);
    }
}
