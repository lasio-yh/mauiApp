namespace StoreApp.Models;

public class OrderItem
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public string ReceiveTime { get; set; }

    public string CompleateTime { get; set; }

    public string AcceptTime { get; set; }

    public string Menu { get; set; }

    public string CustomerAddress { get; set; }

    public string CustomerTel { get; set; }

    public string StoreAddress { get; set; }

    public string StoreTel { get; set; }

    public string CustomerNotice { get; set; }

    public string StoreNotice { get; set; }

    public string DeliveryNotice { get; set; }

    public string OrderCost { get; set; }

    public string PaymentCost { get; set; }

    public string DiscountCost { get; set; }

    public string DeliveraCost { get; set; }
}