using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockScanner.Website.Jobs
{
    [Serializable]
    public class JobAttrs
    {
        public string JobKey { get; private set; }
        public bool IsRunning { get; set; }
        public JobProgress Progress { get; set; }

        public JobAttrs(string jobKey)
        {
            JobKey = jobKey;
        }
    }

    [Serializable]
    public abstract class JobProgress
    {
        public int Index { get; private set; }
        public int Count { get; private set; }

        public abstract string ProgressName { get; }

        protected JobProgress(int index, int count)
        {
            Index = index;
            Count = count;
        }

    }
}