using System;

namespace StockScanner.Interfaces.Store
{
    public interface IIndicatorParam
    {
        Int32 IndicatorId { get; set; }

        String Name { get; set; }

        Int32 Id { get; set; }
    }
}