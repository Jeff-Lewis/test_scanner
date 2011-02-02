

using StockScanner.Interfaces.Store;

namespace StockScanner.Website.JqGrid.Builders
{
    public interface IJqGridBuilder<T> where T:class, INamedEntity
    {
        string BuildGrid(string gridId, string caption, string selectUrl, int pageSize);
    }
}