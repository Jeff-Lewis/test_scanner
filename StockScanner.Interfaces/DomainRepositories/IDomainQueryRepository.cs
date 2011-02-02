using System.Collections.Generic;
using StockScanner.Interfaces.DomainModel;

namespace StockScanner.Interfaces.DomainRepositories
{
    public interface IDomainQueryRepository
    {
        /// <summary>
        /// get stockCompany  by stock Id
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        IStockCompany StockCompany_GetById(int stockId);

        /// <summary>
        /// Get Stock Company by Stock Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        IStockCompany StockCompany_GetByTicker(string ticker);

        /// <summary>
        /// Get All Companies
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<IStockCompany> StockCompany_GetAll(int page, int pageSize);

        /// <summary>
        /// Get companies for the industry
        /// </summary>
        /// <param name="industryId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<IStockCompany> StockCompany_GetByIndustryId(int industryId, int page, int pageSize);

    }
}
