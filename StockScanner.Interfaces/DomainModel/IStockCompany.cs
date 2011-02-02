namespace StockScanner.Interfaces.DomainModel
{
    public interface IStockCompany
    {
        int Id { get; }
        string Ticker { get; }
        string CompanyName { get; }
        string IndustryName { get; }
        string SectorName { get; }
        string ExchangeName { get; }
        int IndustryId { get; }
        int ExchangeId { get; }
        void Register();
        void UnRegister();
        void Activate();
        void DeActivate();
    }
}