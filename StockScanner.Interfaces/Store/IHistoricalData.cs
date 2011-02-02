using System;

namespace StockScanner.Interfaces.Store
{
    public interface IHistoricalData
    {
        Int32 Id { get; set; }

        Int32 StockId { get; set; }

        DateTime Date { get; set; }

        Double OpenValue { get; set; }

        Double HighValue { get; set; }

        Double LowValue { get; set; }

        Double CloseValue { get; set; }

        Int32 Volume { get; set; }

        Int32 PerionId { get; set; }
    }
}