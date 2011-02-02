using System;

namespace StockScanner.Interfaces.Store
{
    public interface IIndicatorParam:INamedEntity
    {
        Int32 IndicatorId { get; set; }

    }
}