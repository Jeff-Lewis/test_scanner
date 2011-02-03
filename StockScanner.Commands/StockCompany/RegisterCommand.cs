using StockScanner.Interfaces.Commands;
using System;

namespace StockScanner.Commands.StockCompany
{
    public class RegisterCommand : IDomainCommand
    {
        public string Ticker { get; private set; }

        public string CompanyName { get; private set; }
        public string ExchangeName { get; private set; }
        public string IndustryName { get; private set; }
        public string SectorName { get; private set; }

        public int? IndustryId { get; private set; }
        public int? SectorId { get; private set; }
        public int? ExchangeId { get; private set; }


        public RegisterCommand(String ticker, String companyName, String exchangeName, String industryName,
                                  String sectorName, int? exchangeId, int? industryId, int? sectorId)
        {
            Ticker = ticker;
            CompanyName = companyName;
            IndustryId = industryId;
            ExchangeId = exchangeId;
            ExchangeName = exchangeName;
            SectorName = sectorName;
            IndustryName = industryName;
            SectorId = sectorId;
        }
    }
}
