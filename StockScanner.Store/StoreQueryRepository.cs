using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Store;

namespace StockScanner.Store
{
    public class StoreQueryRepository : IStoreQueryRepository
    {
        private StockMonitorEntities _store = null;

        public StoreQueryRepository()
        {
            _store = new StockMonitorEntities();
            
        }

        public IQueryable<IVwStockCompany> StockCompanies
        {
            get
            {
                using (var store = new StockMonitorEntities())
                {
                    return _store.vwStockCompanies.Select<vwStockCompany, IVwStockCompany>(u => u);
                }
            }
        }
    }
}
