using Starcounter;

[ReceiptsPage_json]
partial class ReceiptsPage : Page
{
}

[ReceiptsPage_json.Receipts]
partial class ReceiptsPageReceipts : Page
{
    protected override string UriFragment
    {
        get
        {
            return "/launcher/workspace/billing/receipts/" + Data.GetObjectID();
        }
    }
}
