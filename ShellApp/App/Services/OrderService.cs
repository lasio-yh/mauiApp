namespace ShalomCake.Services;

public class OrderService
{
    public async Task<IEnumerable<OrderItem>> GetItems()
    {
        //TODO 주문정보 데이터 가져오기
        await Task.Delay(1000); // Artifical delay to give the impression of work
        var random = new Random().Next();
        var result = new List<OrderItem>();
        for (var i = 0; i < 50; i++)
        {
            result.Add(new OrderItem
            {
                Title = $"OrderID {random}-{i}",
                Id = random,
                AcceptTime = DateTime.Now,
                Status = "접수",
                CustomerAddress = $"경기도 시흥시 월곶중앙로 58번길 블루밍 더 마크 102동 1002호",
                CustomerNotice = $"맵지 않게 해주세요.",
                CustomerTel = $"000-0000-0000",
                StoreAddress = $"",
                StoreTel = $"000-0000-0000",
                StoreNotice = $"",
                DeliveryNotice = $"",
                Menu = $"페퍼로니 피자 라지 1ea, 제로콜라 1.25L, 까르보나라 파스타, 포테이토 피자 1EA",
                CompleateTime = DateTime.Now,
                PickupTime = DateTime.Now,
                DeliveraCost = 3000,
                DiscountCost = 4000,
                OrderCost = 20000,
                PaymentCost = 17000,
                Description = ""
            });
        }
        return result;
    }
}
