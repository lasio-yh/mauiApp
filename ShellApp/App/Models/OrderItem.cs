namespace ShalomCake.Models;

public class OrderItem
{
    public int Id { get; set; }  

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public DateTime AcceptTime { get; set; }

    public DateTime CompleateTime { get; set; }

    public DateTime PickupTime { get; set; }

    public string Menu { get; set; }

    public string CustomerAddress { get; set; }

    public string CustomerTel { get; set; }

    public string StoreAddress { get; set; }

    public string StoreTel { get; set; }

    public string CustomerNotice { get; set; }

    public string StoreNotice { get; set; }

    public string DeliveryNotice { get; set; }

    public int OrderCost { get; set; }

    public int PaymentCost { get; set; }

    public int DiscountCost { get; set; }

    public int DeliveraCost { get; set; }
}