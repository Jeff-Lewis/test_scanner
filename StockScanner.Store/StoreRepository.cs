using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Store;

namespace StockScanner.Store
{
    public class StoreRepository : IStoreRepository
    {
        #region Constructors

        private StoreContext _dataContext = null;

        public StoreRepository()
        {
            _dataContext = new StoreContext();
        }

        #endregion

        #region Queries

        IQueryable<Interfaces.Store.IExchange> IStoreRepository.Exchanges
        {
            get { return _dataContext.Exchanges.Select<Exchange, IExchange>(u => u); }
        }

        IQueryable<Interfaces.Store.IHistoricalData> IStoreRepository.HistDatas
        {
            get { return _dataContext.HistDatas.Select<HistData, IHistoricalData>(u => u); }
        }

        IQueryable<Interfaces.Store.IIndicator> IStoreRepository.Indicators
        {
            get { return _dataContext.Indicators.Select<Indicator, IIndicator>(u => u); }
        }

        IQueryable<Interfaces.Store.IIndicatorParam> IStoreRepository.IndicatorParams
        {
            get { return _dataContext.IndicatorParams.Select<IndicatorParam, IIndicatorParam>(u => u); }
        }

        IQueryable<Interfaces.Store.IIndustry> IStoreRepository.Industries
        {
            get { return _dataContext.Industries.Select<Industry, IIndustry>(u => u); }
        }

        IQueryable<Interfaces.Store.ISector> IStoreRepository.Sectors
        {
            get { return _dataContext.Sectors.Select<Sector, ISector>(u => u); }
        }

        IQueryable<Interfaces.Store.IStock> IStoreRepository.Stocks
        {
            get { return _dataContext.Stocks.Select<Stock, IStock>(u => u); }
        }

        #endregion

        #region Commands

        public int InsertStock(string ticker, string companyName, int industryId, int exchangeId)
        {
            var stock = _dataContext.Stocks.FirstOrDefault(c => string.Compare(c.Ticker, ticker, true) == 0);
            if (stock == null)
            {
                using (StoreContext ctx = new StoreContext())
                {

                    stock = new Stock()
                    {
                        Ticker = ticker,
                        Name = companyName,
                        IndustryId = industryId,
                        ExchangeId = exchangeId
                    };
                    
                    ctx.AddToStocks(stock);

                    //Save to database
                    ctx.SaveChanges();
                } 
            }

            return stock.Id;
        }

        #endregion
    }
}
