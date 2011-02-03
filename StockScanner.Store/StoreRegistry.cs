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
            //Scan(x =>
            //         {
            //             x.TheCallingAssembly();
            //             x.WithDefaultConventions();
            //             //x.ConnectImplementationsToTypesClosing()
            //         }
            //    );
            For<IStoreCommandRepository>().Use<StoreCommandRepository>();
            For<IStoreQueryRepository>().Use<StoreQueryRepository>();
        }
    }
}
