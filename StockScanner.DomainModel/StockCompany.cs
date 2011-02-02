using System.ComponentModel.DataAnnotations;
using StockScanner.Interfaces.DomainModel;

namespace StockScanner.DomainModel
{
    public class StockCompany : DomainModel, IStockCompany
    {
        public int Id { get; private set; }
        public string Ticker { get; private set;}
        public string CompanyName { get; private set; }
        public string IndustryName { get; private set; }
        public string SectorName { get; private set; }
        public string ExchangeName { get; private set; }

        public int IndustryId { get; private set; }
        public int ExchangeId { get; private set; }

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="companyName"></param>
        /// <param name="industryName"></param>
        /// <param name="sectorName"></param>
        /// <param name="exchangeName"></param>
        /// <param name="industryId"></param>
        /// <param name="exchangeId"></param>
        /// <param name="id"></param>
        public StockCompany(string ticker, string companyName, string industryName, string sectorName, string exchangeName, int industryId, int exchangeId, int id = 0)
        {
            Ticker = ticker;
            CompanyName = companyName;
            IndustryName = industryName;
            SectorName = sectorName;
            ExchangeName = exchangeName;
            IndustryId = industryId;
            ExchangeId = exchangeId;
            Id = id;
        }



        #endregion

        /// <summary>
        /// Insert new stock into Stock DB Table 
        /// if validation passed 
        /// </summary>
        public void Register()
        {
            RegisterValidate();

            var command = new Commands.StockCompany.RegisterCommand(Ticker, CompanyName, IndustryId, ExchangeId);
            Dispatcher.Dispatch(command);
        }

        #region Validation

        /// <summary>
        /// 
        /// </summary>
        private void RegisterValidate() {
            
            if(string.IsNullOrEmpty(Ticker))
                throw new ValidationException();
        }

        #endregion

        public void UnRegister(){}
        public void Activate(){}
        public void DeActivate(){}


    }
}
