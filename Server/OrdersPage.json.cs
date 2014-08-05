using Starcounter;
using System;

[OrdersPage_json]
partial class OrdersPage : Page
{
    void Handle(Input.RequestReceipt input)
    {
        var receipt = new Billing.Receipt();
        receipt.DateTime = DateTime.Now;

        for (int i = Orders.Count - 1; i >= 0; i--)
        {
            OrdersPageOrders order = Orders[i];
            ((Billing.Order)order.Data).Receipt = receipt;
            Orders.Remove(order);
        }

        Transaction.Commit();
    }
}

[OrdersPage_json.Orders]
partial class OrdersPageOrders : Page
{
}

