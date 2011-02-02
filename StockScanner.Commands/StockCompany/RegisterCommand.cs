using StockScanner.Interfaces.Commands;

namespace StockScanner.Commands.StockCompany
{
    public class RegisterCommand : IDomainCommand
    {
        public string Ticker { get; private set; }

        public string CompanyName { get; private set; }

        public int IndustryId { get; private set; }

        public int ExchangeId { get; private set; }

        public RegisterCommand(string ticker, string companyName, int industryId, int exchangeId)
        {
            Ticker = ticker;
            CompanyName = companyName;
            IndustryId = industryId;
            ExchangeId = exchangeId;
        }
    }
}
