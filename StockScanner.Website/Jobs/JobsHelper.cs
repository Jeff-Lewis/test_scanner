using System.Web;

namespace StockScanner.Website.Jobs
{
    public class JobsHelper
    {
        private MvcApplication _mvcApplication = null;

        #region Singelton
        private static JobsHelper _current = null;
        private static JobAttrs _jobAttrs = new JobAttrs(SyncStockHistoricalDataJob.JOB_KEY);

        public static JobsHelper Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new JobsHelper();
                }
                return _current;
            }
        }

        private JobsHelper()
        {
        }
        #endregion

        #region Jobs
        
        #endregion

        public void SetJobAttrs(JobAttrs jobAttrs)
        {
            _jobAttrs = jobAttrs;
        }

        public void AbortSyncStockHistoricalDataJob()
        {
            _mvcApplication._syncStockHistoricalDataJob.Abort();
        }

        public void StartSyncStockHistoricalDataJob()
        {
            _mvcApplication._syncStockHistoricalDataJob.Start(true);
        }

        public JobAttrs GetSyncStockHistoricalDataJobAttrs()
        {
            return this.GetJobAttrs(SyncStockHistoricalDataJob.JOB_KEY);
        }

        public JobAttrs GetJobAttrs(string key)
        {
            return _jobAttrs;
        }


        internal void Initialize(MvcApplication mvcApplication)
        {
            _mvcApplication = mvcApplication;
        }
    }
}