using System;

namespace StockScanner.Interfaces.Store
{
    public interface IStock
    {
        Int32 Id { get; set; }

        String Ticker { get; set; }

        int? ExchangeId { get; set; }

        String Name { get; set; }

        int? IndustryId { get; set; }
    }
}