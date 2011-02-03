using System.Linq;

namespace StockScanner.Interfaces.Store
{
    public interface IStoreQueryRepository
    {
        IQueryable<IVwStockCompany> StockCompanies { get; }
    }
}
