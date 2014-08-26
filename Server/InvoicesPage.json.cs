using Starcounter;

[InvoicesPage_json]
partial class InvoicesPage : Page
{
}

[InvoicesPage_json.Invoices]
partial class InvoicesPageInvoices : Page
{
    protected override string UriFragment
    {
        get
        {
            return "/launcher/workspace/billing/invoices/" + Data.GetObjectID();
        }
    }
}
