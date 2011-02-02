using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Commands;
using StockScanner.Dispatchers;
using StockScanner.Interfaces.Dispatchers;
using StockScanner.Interfaces.DomainModel;
using StructureMap;

namespace StockScanner.DomainModel
{
    public abstract class DomainModel : IDomainModel
    {
        protected ICommandDispatcher Dispatcher { get; private set; }
 
        protected DomainModel()
        {
            Dispatcher = ObjectFactory.GetInstance<ICommandDispatcher>();

        }
    }
}
