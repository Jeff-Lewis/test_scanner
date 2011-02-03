using System;

namespace StockScanner.Interfaces.DomainRepositories
{
    public interface IDomainCommandRepository
    {
        void StockCompanyRegister(String ticker, String companyName, String exchangeName, String industryName,
                                  String sectorName, int? exchangeId, int? industryId, int? sectorId);
    }
}
