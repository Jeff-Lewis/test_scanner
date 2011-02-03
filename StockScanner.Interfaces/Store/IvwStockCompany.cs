using System;

namespace StockScanner.Interfaces.Store
{
    public interface IVwStockCompany
    {
        Int32 Id { get; set; }

        String Ticker { get; set; }

        int? ExchangeId { get; set; }

        String CompanyName { get; set; }

        int? IndustryId { get; set; }

        String ExchangeName { get; set; }

        String IndustryName { get; set; }

        int? SectorId { get; set; }

        String SectorName { get; set; }
    }
}