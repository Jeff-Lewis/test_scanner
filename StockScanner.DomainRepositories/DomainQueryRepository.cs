using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.DomainModel;
using StockScanner.Interfaces.DomainModel;
using StockScanner.Interfaces.DomainRepositories;
using StockScanner.Interfaces.Store;

namespace StockScanner.DomainRepositories
{

    public class DomainQueryRepository : IDomainQueryRepository
    {
        protected IStoreRepository DbContext { get; private set; }
        protected List<IExchange> ExchangeList { get; private set; }
        protected List<IIndustry> IndustryList { get; private set; }
        protected List<ISector> SectorList { get; private set; }

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DomainQueryRepository(IStoreRepository context)
        {
            DbContext = context;

            Initialize();
        }

        /// <summary>
        /// Prepare Lists
        /// </summary>
        private  void Initialize()
        {
            ExchangeList = DbContext.Exchanges.ToList();
            IndustryList = DbContext.Industries.ToList();
            SectorList = DbContext.Sectors.ToList();
        }

        #endregion

        #region Private members

        /// <summary>
        /// Create domain model IStockCompany from persistent model IStock
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private  IStockCompany ToStockCompany(IStock stock)
        {
            IStockCompany company = null;

            if (stock != null)
            {
                var exchange = ExchangeList.FirstOrDefault(e => e.Id == stock.ExchangeId);
                var industry = IndustryList.FirstOrDefault(i => i.Id == stock.IndustryId);
                ISector sector = null;
                if (industry != null)
                    sector = SectorList.FirstOrDefault(s => s.Id == industry.SectorId);

                company = new StockCompany(stock.Ticker, stock.Name,
                                           industry == null ? string.Empty : industry.IndustryName,
                                           sector == null ? string.Empty : sector.SectorName,
                                           exchange == null ? string.Empty : exchange.Name, stock.IndustryId ?? 0,
                                           stock.ExchangeId ?? 0, stock.Id);
            }
            return company;
        }

        #endregion

        #region StockCompany

        /// <summary>
        /// get stockCompany  by stock Id
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public IStockCompany StockCompany_GetById(int stockId)
        {
            var stock = DbContext.Stocks.FirstOrDefault(s => s.Id == stockId);
            return ToStockCompany(stock);
        }

        /// <summary>
        /// Get Stock Company by Stock Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public IStockCompany StockCompany_GetByTicker(string ticker)
        {
            var stock = DbContext.Stocks.FirstOrDefault(s => string.Compare( s.Ticker, ticker, true) == 0);
            return ToStockCompany(stock);
        }

        /// <summary>
        /// Get All Companies
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<IStockCompany> StockCompany_GetAll(int page, int pageSize)
        {
            var stocks = DbContext.Stocks.Skip(page*pageSize).Take(pageSize);
            return stocks.Select(stock => ToStockCompany(stock)).ToList();
        }

        /// <summary>
        /// Get companies for the industry
        /// </summary>
        /// <param name="industryId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<IStockCompany> StockCompany_GetByIndustryId(int industryId, int page, int pageSize)
        {
            var stocks = DbContext.Stocks.Where(s=>s.IndustryId == industryId).Skip(page * pageSize).Take(pageSize);
            return stocks.Select(stock => ToStockCompany(stock)).ToList();
        }

        #endregion

    }
}
