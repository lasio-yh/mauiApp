namespace StoreApp.Services;

public class OrderService
{
    public async Task<IEnumerable<OrderItem>> GetItems()
    {
        //TODO 주문정보 데이터 가져오기
        await Task.Delay(1000); // Artifical delay to give the impression of work
        var random = new Random().Next();
        var result = new List<OrderItem>();
        for (var i = 0; i < 2; i++)
        {
            result.Add(new OrderItem
            {
                Title = $"OrderID {random}-{i}",
                Id = $"{random}",
                ReceiveTime = $"{DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분")}",
                Status = "접수 대기",
                CustomerAddress = $"경기도 시흥시 월곶중앙로 58번길 블루밍 더 마크 102동 1002호",
                CustomerNotice = $"맵지 않게 해주세요.",
                CustomerTel = $"000-0000-0000",
                StoreAddress = $"",
                StoreTel = $"000-0000-0000",
                StoreNotice = $"일회용 용기 빼주세요.",
                DeliveryNotice = $"조심히 와주세요.",
                Menu = $"페퍼로니 피자 라지 1ea, 제로콜라 1.25L, 까르보나라 파스타, 포테이토 피자 1EA",
                CompleateTime = $"{DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분")}",
                AcceptTime = $"{DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분")}",
                DeliveraCost = $"1000 원",
                DiscountCost = $"1000 원",
                OrderCost = $"총 1000 원",
                PaymentCost = $"총 1000 원",
                Description = ""
            });
        }
        return result;
    }

    public async Task<string> JsonSerializeAsync(object obj)
    {
        var result = string.Empty;
        using (var stream = new MemoryStream())
        {
            await JsonSerializer.SerializeAsync(stream, obj, obj.GetType());
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            result = await reader.ReadToEndAsync();
        }
        return result;
    }
}
