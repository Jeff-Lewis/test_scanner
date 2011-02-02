using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Store;

namespace StockScanner.Website.Jobs
{
    [Serializable]
    public class SyncDataProgress : JobProgress
    {
        public IStock Stock { get; private set; }

        public SyncDataProgress(IStock stock, int index, int count)
            :base(index, count)
        {
            Stock = stock;
        }

        public override string ToString()
        {
            if(Stock != null)
                return string.Format("{0} of {1} - {2}: {3}", Index, Count, Stock.Ticker, Stock.Name);

            return string.Empty;
        }

        public override string ProgressName
        {
            get { return this.ToString(); }
        }
    }

    [Serializable]
    public class SyncDataProgressEventArgs: EventArgs
    {
        public SyncDataProgress Progress { get; private set; }

        public SyncDataProgressEventArgs(SyncDataProgress progress)
        {
            Progress = progress;
        }

        public SyncDataProgressEventArgs(IStock stock, int index, int count)
        {
            Progress = new SyncDataProgress(stock, index, count);
        }
    }
}
