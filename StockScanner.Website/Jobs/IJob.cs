namespace StockScanner.Website.Jobs
{
    public interface IJob
    {
        string JobKey { get;}

        /// <summary>
        /// Stop job
        /// </summary>
        void Abort();

        /// <summary>
        /// Start Job
        /// </summary>
        void Start();
    }
}