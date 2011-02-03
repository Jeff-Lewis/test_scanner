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
        protected IStoreCommandRepository _repository { get; private set; }

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public DomainCommandRepository(IStoreCommandRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public void StockCompanyRegister(String ticker, String companyName, String exchangeName, String industryName,
                                  String sectorName, int? exchangeId, int? industryId, int? sectorId)
        {
            int companyId = 0;
            string message;

            _repository.StockCompany_Register(ticker, companyName, exchangeName, industryName, sectorName, exchangeId, industryId, sectorId, out companyId, out message);
        }

    }
}
