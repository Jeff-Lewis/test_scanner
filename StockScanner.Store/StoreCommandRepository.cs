using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Store;

namespace StockScanner.Store
{
    public class StoreCommandRepository : IStoreCommandRepository
    {

        /// <summary>
        /// Register new company
        /// </summary>
        /// <param name="ticker"></param>
        /// <param name="companyName"></param>
        /// <param name="exchangeName"></param>
        /// <param name="industryName"></param>
        /// <param name="sectorName"></param>
        /// <param name="exchangeId"></param>
        /// <param name="industryId"></param>
        /// <param name="sectorId"></param>
        /// <param name="companyId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void StockCompany_Register(string ticker, string companyName, string exchangeName, string industryName, string sectorName, int? exchangeId, int? industryId, int? sectorId, out int companyId, out string message)
        {
            string msg;
            int id = 0;

            var outCompanyId = new ObjectParameter("o_Company", typeof(int));
            var outMessage = new ObjectParameter("o_Message", typeof(string));

            using (var db = new StockMonitorEntities())
            {
                db.spStockCompany_Register(ticker, companyName, exchangeName, industryName, sectorName, exchangeId,
                                           industryId, sectorId, outCompanyId, outMessage);

                id = (int)outCompanyId.Value;
                msg = (string)outMessage.Value;
            }
            companyId = id;
            message = msg;
        }

        /// <summary>
        /// Unregister Company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public void StockCompany_UnRegister(int? companyId, out int status, out string message)
        {
            string msg;
            int stat = 0;

            var outStatusId = new ObjectParameter("o_Status", typeof(int));
            var outMessage = new ObjectParameter("o_Message", typeof(string));

            using (var db = new StockMonitorEntities())
            {
                db.spStockCompany_UnRegister(companyId, outStatusId, outMessage);

                stat = (int)outStatusId.Value;
                msg = (string)outMessage.Value;
            }
            status = stat;
            message = msg;
        }

        /// <summary>
        /// Activate Company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public void StockCompany_Activate(int? companyId, out int status, out string message)
        {
            string msg;
            int stat = 0;

            var outStatusId = new ObjectParameter("o_Status", typeof(int));
            var outMessage = new ObjectParameter("o_Message", typeof(string));

            using (var db = new StockMonitorEntities())
            {
                db.spStockCompany_Activate(companyId, outStatusId, outMessage);

                stat = (int)outStatusId.Value;
                msg = (string)outMessage.Value;
            }
            status = stat;
            message = msg;
        }

        /// <summary>
        /// Make company Inactive
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public void StockCompany_DeActivate(int? companyId, out int status, out string message)
        {
            string msg;
            int stat = 0;

            var outStatusId = new ObjectParameter("o_Status", typeof(int));
            var outMessage = new ObjectParameter("o_Message", typeof(string));

            using (var db = new StockMonitorEntities())
            {
                db.spStockCompany_DeActivate(companyId, outStatusId, outMessage);

                stat = (int)outStatusId.Value;
                msg = (string)outMessage.Value;
            }
            status = stat;
            message = msg;
        }
    }
}
