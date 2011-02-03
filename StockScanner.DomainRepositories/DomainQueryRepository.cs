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
        private IStoreQueryRepository _repository = null;

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public DomainQueryRepository(IStoreQueryRepository repository)
        {
            _repository = repository;

            Initialize();
        }

        /// <summary>
        /// Prepare Lists
        /// </summary>
        private  void Initialize()
        {

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
            var c = _repository.StockCompanies.FirstOrDefault(s => s.Id == stockId);

            return new StockCompany(c.Ticker, c.CompanyName,
                                    c.IndustryName, c.SectorName, c.ExchangeName, c.IndustryId, c.ExchangeId, c.SectorId, c.Id);
            
        }


        /// <summary>
        /// Get Stock Company by Stock Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public IStockCompany StockCompany_GetByTicker(string ticker)
        {
            var c = _repository.StockCompanies.FirstOrDefault(s => string.Compare(s.Ticker, ticker, true) == 0);
            return new StockCompany(c.Ticker, c.CompanyName,
                                          c.IndustryName, c.SectorName, c.ExchangeName, c.IndustryId, c.ExchangeId, c.SectorId, c.Id);
        }

        /// <summary>
        /// Get All Companies
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<IStockCompany> StockCompany_GetAll(int page, int pageSize)
        {

            var companies = 
                _repository.StockCompanies
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

            return companies.Select(c => new StockCompany(c.Ticker, c.CompanyName, c.IndustryName, c.SectorName, c.ExchangeName, c.IndustryId, c.ExchangeId, c.SectorId, c.Id) as IStockCompany).ToList();
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
            var companies =
                _repository.StockCompanies
                    .Where(s => s.IndustryId == industryId)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

            return companies.Select(c => new StockCompany(c.Ticker, c.CompanyName, c.IndustryName, c.SectorName, c.ExchangeName, c.IndustryId, c.ExchangeId, c.SectorId, c.Id) as IStockCompany).ToList();

        }

        #endregion

    }
}
