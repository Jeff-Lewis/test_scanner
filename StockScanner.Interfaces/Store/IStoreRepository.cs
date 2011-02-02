using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Interfaces.Store
{
    public interface IStoreRepository
    {
        int InsertStock(string ticker, string companyName, int industryId, int exchangeId);
        IQueryable<IExchange> Exchanges { get; }
        IQueryable<IHistoricalData> HistDatas { get; }
        IQueryable<IIndicator> Indicators { get; }
        IQueryable<IIndicatorParam> IndicatorParams { get; }
        IQueryable<IIndustry> Industries { get; }
        IQueryable<ISector> Sectors { get; }
        IQueryable<IStock> Stocks { get; }
    }
}
