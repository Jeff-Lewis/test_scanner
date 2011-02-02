using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Store;
using StructureMap.Configuration.DSL;

namespace StockScanner.Store
{
    public class StoreRegistry : Registry
    {
        public StoreRegistry()
        {
            For<IStoreRepository>().Use<StoreRepository>();
        }
    }
}
