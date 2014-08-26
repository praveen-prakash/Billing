using Starcounter;
using System;

[OrdersPage_json]
partial class OrdersPage : Page
{
    void Handle(Input.Requestinvoice input)
    {
        var invoice = new Billing.Invoice();
        invoice.DateTime = DateTime.Now;
        invoice.TotalPrice = 0;

        for (int i = Orders.Count - 1; i >= 0; i--)
        {
            OrdersPageOrders order = Orders[i];
            Billing.Order orderData = (Billing.Order)order.Data;
            invoice.TotalPrice += orderData.Offer.Price;
            orderData.Invoice = invoice;
            Orders.Remove(order);
        }

        Transaction.Commit();
    }
}

[OrdersPage_json.Orders]
partial class OrdersPageOrders : Page
{
}

