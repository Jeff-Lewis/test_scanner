
using StructureMap.Configuration.DSL;

namespace StockScanner.Website.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            //For<IStockMonitorService>().Use<StockMonitorService>();
        }
    }
}