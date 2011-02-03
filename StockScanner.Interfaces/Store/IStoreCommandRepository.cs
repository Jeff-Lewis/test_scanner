using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Interfaces.Store
{
    public interface IStoreCommandRepository
    {
        void StockCompany_Register(String ticker, String companyName, String exchangeName, String industryName,
                                  String sectorName, int? exchangeId, int? industryId, int? sectorId, out int companyId,
                                  out string message);


        void StockCompany_UnRegister(int? companyId, out int status, out string message);

        void StockCompany_Activate(int? companyId, out int status, out string message);

        void StockCompany_DeActivate(int? companyId, out int status, out string message);
    }
}
