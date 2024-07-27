public enum OrderType { Buy, Sell }


public struct TradeOrderStruct
{
    public long OrderId;
    public string Symbol;
    public decimal Price;
    public int Quantity;
    public DateTime Timestamp;
    public OrderType Type;

    public TradeOrderStruct(long orderId, string symbol, decimal price, int quantity, OrderType type)
    {
        OrderId = orderId;
        Symbol = symbol;
        Price = price;
        Quantity = quantity;
        Timestamp = DateTime.UtcNow;
        Type = type;
    }
}


// Usage
TradeOrderStruct orderStruct = new TradeOrderStruct(12345, "AAPL", 150.25m, 100, OrderType.Buy);


public class TradeOrderClass
{
    public long OrderId { get; set; }
    public string Symbol { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Timestamp { get; set; }
    public OrderType Type { get; set; }

    public TradeOrderClass(long orderId, string symbol, decimal price, int quantity, OrderType type)
    {
        OrderId = orderId;
        Symbol = symbol;
        Price = price;
        Quantity = quantity;
        Timestamp = DateTime.UtcNow;
        Type = type;
    }
}

// Usage
TradeOrderClass orderClass = new TradeOrderClass(12345, "AAPL", 150.25m, 100, OrderType.Buy);



const int iterations = 100_000_000;

Stopwatch sw = new Stopwatch();

// Struct benchmark
sw.Start();
for (int i = 0; i < iterations; i++)
{
    TradeOrderStruct order = new TradeOrderStruct(i, "AAPL", 150.25m, 100, OrderType.Buy);
}
sw.Stop();
Console.WriteLine($"Struct time: {sw.ElapsedMilliseconds}ms");

sw.Reset();

// Class benchmark
sw.Start();
for (int i = 0; i < iterations; i++)
{
    TradeOrderClass order = new TradeOrderClass(i, "AAPL", 150.25m, 100, OrderType.Buy);
}
sw.Stop();
Console.WriteLine($"Class time: {sw.ElapsedMilliseconds}ms");
