namespace StockScanner.Interfaces.DomainRepositories
{
    public interface IDomainCommandRepository
    {
        void StockCompanyRegister(string ticker, string companyName, int industryId, int exchangeId);
    }
}
