using StockScanner.DomainModel;
using StockScanner.Interfaces.Dispatchers;
using StockScanner.Interfaces.DomainModel;
using StockScanner.Interfaces.DomainRepositories;
using StructureMap;

namespace StockScanner.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.ConfigureStructureMap();

            var repository = ObjectFactory.GetInstance<IDomainQueryRepository>();

            var company = repository.StockCompany_GetById(100);

            IStockCompany newCompany = new StockCompany("FAKE-ME2", company.CompanyName, company.IndustryName, company.SectorName, company.ExchangeName,  company.IndustryId, company.ExchangeId, company.SectorId);
            
            newCompany.Register();

        }
    }
}

