using System;

namespace StockScanner.Interfaces.Store
{
    public interface ISector
    {
        Int32 Id { get; set; }

        String SectorName { get; set; }
    }
}