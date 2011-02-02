using System;

namespace StockScanner.Interfaces.Store
{
    public interface IIndustry:IStoreEntity
    {

        Int32 SectorId { get; set; }
        String IndustryName { get; set; }
    }
}