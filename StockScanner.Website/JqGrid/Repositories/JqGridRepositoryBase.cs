using System.Linq;
using StockScanner.Interfaces.Store;


namespace StockScanner.Website.JqGrid.Repositories
{
    public abstract class JqGridRepositoryBase<T> : IJqGridRepository<T> where T:class, INamedEntity
    {
        //protected IStockMonitorService SmService { get; private set; }
        
        //protected JqGridRepositoryBase(IStockMonitorService service)
        //{
        //    SmService = service;
        //}

        //protected JqGridRepositoryBase() {
        //    SmService = new StockMonitorService();
        //}

        public abstract int Count(GridSettings gridSettings);

        public abstract IQueryable<T> Get(GridSettings gridSettings);

        public abstract string[] GetNames();

        public abstract IQueryable<T> Filter(IQueryable<T> list, Rule rule);

        public abstract IQueryable<T> Order(IQueryable<T> customers, string sortColumn, string sortOrder);
    }
}