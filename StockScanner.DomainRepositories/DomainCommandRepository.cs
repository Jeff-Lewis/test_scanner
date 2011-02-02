using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.DomainRepositories;
using StockScanner.Interfaces.Store;

namespace StockScanner.DomainRepositories
{
    public class DomainCommandRepository:IDomainCommandRepository
    {
        protected IStoreRepository DbContext { get; private set; }

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DomainCommandRepository(IStoreRepository context)
        {
            DbContext = context;
        }

        #endregion

        public void StockCompanyRegister(string ticker, string companyName, int industryId, int exchangeId)
        {
            DbContext.InsertStock(ticker, companyName, industryId, exchangeId);
        }
    }
}
