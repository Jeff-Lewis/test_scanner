
using StockScanner.Interfaces.Store;

namespace StockScanner.Website.JqGrid.Models
{
    public interface IJqGridStockModel: IStock
    {
        string IndustryName { get; set; }
        string ExchangeName { get; set; }
    }
}