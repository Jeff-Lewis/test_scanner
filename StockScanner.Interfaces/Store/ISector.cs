using System;

namespace StockScanner.Interfaces.Store
{
    public interface ISector:IStoreEntity
    {
        String SectorName { get; set; }
    }
}