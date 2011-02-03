using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.CommandHandlers;
using StockScanner.Interfaces.DomainRepositories;

namespace StockScanner.CommandHandlers.StockCompany
{
    public class RegisterCommandHandler : IDomainCommandHandler<Commands.StockCompany.RegisterCommand>
    {
        private IDomainCommandRepository _repository = null;

        public RegisterCommandHandler(IDomainCommandRepository repository)
        {
            _repository = repository;
        }

        public void Handle(Commands.StockCompany.RegisterCommand command)
        {
            _repository.StockCompanyRegister(command.Ticker, command.CompanyName, command.ExchangeName, command.IndustryName, command.SectorName, command.ExchangeId, command.IndustryId, command.SectorId);
        }
    }
}
