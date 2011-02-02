using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.CommandHandlers;
using StockScanner.Interfaces.Dispatchers;
using StructureMap.Configuration.DSL;

namespace StockScanner.Dispatchers
{
    public class DispatcherRegistry: Registry
    {
        public DispatcherRegistry()
        {
            For<IQueryDispatcher>().Use<QueryDispatcher>();
            For<ICommandDispatcher>().Use<CommandDispatcher>();
        }
    }
}
