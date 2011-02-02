using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using StockScanner.Interfaces.Store;


namespace StockScanner.Website.Jobs
{
    public delegate void SyncDataProgressDelegate(SyncDataProgressEventArgs args);

    public class SyncStockHistoricalDataJob : IJob
    {
        public const string JOB_KEY = "SyncStockHistoricalDataJob";

        private bool _isRunning = false;

        #region Events

        public event EventHandler Started;
        public event EventHandler Stopped;

        private void OnStarted()
        {
            if (Started != null)
            {
                Started(this, new EventArgs());
            }
        }

        private void OnStopped()
        {
            if (Stopped != null)
            {
                Stopped(this, new EventArgs());
            }
        }

        /// <summary>
        /// Subscribe to the event to get progress notifications
        /// </summary>
        protected event SyncDataProgressDelegate SyncDataProgressEvent;

        public void SubscribeSyncDataProgressEvent(SyncDataProgressDelegate eventHandler)
        {
            SyncDataProgressEvent += eventHandler;
        }

        public void UnsubscribeSyncDataProgressEvent(SyncDataProgressDelegate eventHandler)
        {
            SyncDataProgressEvent -= eventHandler;
        }

        /// <summary>
        /// Dispatch event
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void OnSyncDataProgressEvent(IStock stock, int index, int count)
        {
            if (SyncDataProgressEvent != null)
            {
                SyncDataProgressEvent(new SyncDataProgressEventArgs(stock, index, count));
            }
        }

        #endregion

        public  SyncStockHistoricalDataJob()
        {
            LastRunDate = DateTime.MinValue;
        }

        /// <summary>
        /// Stop job
        /// </summary>
        public void Abort()
        {
            _isRunning = false;
        }

        /// <summary>
        /// Start Job
        /// </summary>
        public void Start()
        {
            //_isRunning = true;
            //OnStarted();

            //var stoks = _service.GetStocks();
            //var i = 0;
            //foreach (var stock in stoks)
            //{
            //    if (!_isRunning)
            //        break;

            //    i++;

            //    OnSyncDataProgressEvent(stock, i, stoks.Count);
            //    Thread.Sleep(200);

            //    var histdata = _service.DownloadHistoricalData(stock.Ticker, EnumPeriodType.Weekly);
            //    histdata.AddRange(_service.DownloadHistoricalData(stock.Ticker, EnumPeriodType.Daily));

            //    foreach (var data in histdata)
            //    {
            //        _service.UpdateHistData(data);
            //    }
            //}

            //LastRunDate = DateTime.Today;

            //OnStopped();
            //_isRunning = false;
        }


        /// <summary>
        /// Get Job Key
        /// </summary>
        public string JobKey
        {
            get { return JOB_KEY; }
        }

        public bool AllowToRun
        {
            get
            {
                return !_isRunning;
            }
        }

        public DateTime LastRunDate { get; private set; }

        internal void Start(bool reset)
        {
            if (reset)
                LastRunDate = DateTime.MinValue;

            Start();
        }
    }
}