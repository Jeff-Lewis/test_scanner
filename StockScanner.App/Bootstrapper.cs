using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.CommandHandlers;
using StockScanner.Dispatchers;
using StockScanner.DomainRepositories;
using StockScanner.Store;
using StructureMap;

namespace StockScanner.App
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new DomainRepositoryRegistry());
                x.AddRegistry(new StoreRegistry());
                x.AddRegistry(new DispatcherRegistry());
                x.AddRegistry(new CommandHandlerRegistry());
            });

            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}
