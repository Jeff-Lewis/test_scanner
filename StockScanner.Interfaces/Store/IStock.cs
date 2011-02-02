using System;

namespace StockScanner.Interfaces.Store
{
    public interface IStock:INamedEntity
    {
        String Ticker { get; set; }

        int? ExchangeId { get; set; }

        int? IndustryId { get; set; }
    }
}