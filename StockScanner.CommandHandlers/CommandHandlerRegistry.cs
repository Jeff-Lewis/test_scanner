using StockScanner.CommandHandlers.StockCompany;
using StockScanner.Interfaces.CommandHandlers;
using StockScanner.Interfaces.QueryHandlers;
using StructureMap.Configuration.DSL;

namespace StockScanner.CommandHandlers
{
    public class CommandHandlerRegistry: Registry
    {
        public CommandHandlerRegistry()
        {
            For<IDomainCommandHandler<Commands.StockCompany.RegisterCommand>>().Use<RegisterCommandHandler>();
        }
    }
}
