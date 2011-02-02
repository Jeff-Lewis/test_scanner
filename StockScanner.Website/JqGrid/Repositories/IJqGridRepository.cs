using System.Linq;
using StockScanner.Interfaces.Store;


namespace StockScanner.Website.JqGrid.Repositories
{
    public interface IJqGridRepository<T> where T:class, INamedEntity
    {
        int Count(GridSettings gridSettings);
        IQueryable<T> Get(GridSettings gridSettings);
        string[] GetNames();
        IQueryable<T> Filter(IQueryable<T> list, Rule rule);
        IQueryable<T> Order(IQueryable<T> customers, string sortColumn, string sortOrder);
    }
}