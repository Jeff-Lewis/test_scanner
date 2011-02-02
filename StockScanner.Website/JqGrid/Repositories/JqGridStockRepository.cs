using System.Collections.Generic;
using System.Linq;
using StockScanner.Interfaces.Store;
using StockScanner.Website.JqGrid.Models;

namespace StockScanner.Website.JqGrid.Repositories
{
    public class JqGridStockRepository : JqGridRepositoryBase<IJqGridStockModel>
    {
        public List<IJqGridStockModel> Stocks { get; private set; }
        public List<IIndustry> Industries { get; private set; }
        public List<ISector> Sectors { get; private set; }

        #region Constructors

        public JqGridStockRepository()
        {
            //var stocks = SmService.GetStocks();
            //Industries = SmService.GetIndustries();
            //Sectors = SmService.GetSectors();

            //var result =
            //    (from s in stocks join i in Industries on s.IndustryId equals i.Id select new JqGridStockModel { Id = s.Id, IndustryId = i.Id, IndustryName = i.Name, Name = s.Name, Ticker = s.Ticker, ExchangeId = i.SectorId });
            //result = (from r in result join s in Sectors on r.ExchangeId equals s.Id select new JqGridStockModel { Id = r.Id, IndustryId = r.IndustryId, IndustryName = r.IndustryName, Name = r.Name, Ticker = r.Ticker, ExchangeId = r.ExchangeId, ExchangeName = s.Name });
            //Stocks = result.Cast<IJqGridStockModel>().ToList();
        }

        #endregion


        /// <summary>
        /// Get Stock count based on grid filter
        /// </summary>
        /// <param name="gridSettings"></param>
        /// <returns></returns>
        public override int Count(GridSettings gridSettings)
        {
            var list = Stocks.AsQueryable();

            if (gridSettings.IsSearch) {
                foreach (var rule in gridSettings.Where.rules) {
                    list = Filter(list, rule);
                }
            }
            return list.Count();
        }

        public override IQueryable<IJqGridStockModel> Get(GridSettings gridSettings) {

            var list = Order(Stocks.AsQueryable(), gridSettings.SortColumn, gridSettings.SortOrder);

            if (gridSettings.IsSearch) {
                foreach (var rule in gridSettings.Where.rules) {
                    list = Filter(list, rule);
                }
            }

            return list.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public override string[] GetNames() {
            return (from s in Stocks select s.Ticker).Distinct().ToArray();

        }

        public string[] GetIndustryNames() {
            return (from s in Industries select s.IndustryName).Distinct().ToArray();

        }

        public string[] GetSectorNames() {
            return (from s in Sectors select s.SectorName).Distinct().ToArray();

        }

        public override IQueryable<IJqGridStockModel> Filter(IQueryable<IJqGridStockModel> list, Rule rule) {
            /*
            if (rule.field == "CustomerId") {
                int result;
                if (!int.TryParse(rule.data, out result))
                    return customers;
                return customers.Where(c => c.CustomerID == Convert.ToInt32(rule.data));

            }
            if (rule.field == "Name")
                return from c in customers
                       where c.FirstName.Contains(rule.data) || c.LastName.Contains(rule.data)
                       select c;
            if (rule.field == "Company")
                return customers.Where(c => c.CompanyName.Contains(rule.data));
            if (rule.field == "EmailAddress")
                return customers.Where(c => c.EmailAddress.Contains(rule.data));
            if (rule.field == "Last Modified") {
                DateTime result;
                if (!DateTime.TryParse(rule.data, out result))
                    return customers;
                if (result < new DateTime(1754, 1, 1)) // sql can't handle dates before 1-1-1753
                    return customers;
                return customers.Where(c => c.ModifiedDate.Date == Convert.ToDateTime(rule.data).Date);
            }
            if (rule.field == "Telephone")
                return customers.Where(c => c.Phone.Contains(rule.data));
            return customers;
             */
            return Stocks.AsQueryable();
        }

        public override IQueryable<IJqGridStockModel> Order(IQueryable<IJqGridStockModel> customers, string sortColumn, string sortOrder) {
            return Stocks.AsQueryable();
        }
    }
}