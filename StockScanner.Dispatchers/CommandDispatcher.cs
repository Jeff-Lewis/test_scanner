using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.CommandHandlers;
using StockScanner.Interfaces.Commands;
using StockScanner.Interfaces.Dispatchers;
using StructureMap;

namespace StockScanner.Dispatchers
{
    public class CommandDispatcher: ICommandDispatcher
    {
        public void Dispatch<TCommand>(TCommand command) where TCommand : IDomainCommand
        {

            var handlers = ObjectFactory.GetAllInstances<IDomainCommandHandler<TCommand>>();

            //var handlers = new List<IDomainCommandHandler<TCommand>>();
            //Get direct handlers
            //handlers.Add(new RegisterCommandHandler() as IDomainCommandHandler<TCommand>);

            //Get indirect handlers 
            //handlers.Add(...

            foreach (var handler in handlers)
            {
                handler.Handle(command);
            }
        }
    }
}
