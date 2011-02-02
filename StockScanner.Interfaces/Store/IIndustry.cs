using System;

namespace StockScanner.Interfaces.Store
{
    public interface IIndustry
    {
        Int32 Id { get; set; }

        Int32 SectorId { get; set; }
        String IndustryName { get; set; }
    }
}