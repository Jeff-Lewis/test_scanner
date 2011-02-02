using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using StockScanner.Website.Jobs;
using StockScanner.Website.StructureMap;
using StructureMap;

namespace StockScanner.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private string CallbackPageUrl = string.Empty;
        private const string CacheItemKey = "CacheItemKeyWS";
        public SyncStockHistoricalDataJob _syncStockHistoricalDataJob;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("ChartImg.axd/{*pathInfo}");
            routes.IgnoreRoute("{controller}/ChartImg.axd/{*pathInfo}");
            routes.IgnoreRoute("{controller}/{action}/ChartImg.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            InitializeContainer();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            JobsHelper.Current.Initialize(this);
            RegisterJobs();
            RegisterCacheEntry();
        }


        public void InitializeContainer()
        {
            Bootstrapper.ConfigureStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        protected void Application_BeginRequest(Object sender, EventArgs e) {
            CallbackPageUrl = WebConfigurationManager.AppSettings["CallbackPageUrl"];
            if (!string.IsNullOrEmpty(CallbackPageUrl) && HttpContext.Current.Request.Url.ToString() == CallbackPageUrl) {
                // Add the item in cache and when succesful, do the work.
                RegisterCacheEntry();
            }
        }

        #region Private
        /// <summary>
        /// Register a cache entry which expires in 1 minute and gives us a callback.
        /// </summary>
        /// <returns></returns>
        private void RegisterCacheEntry() {

            // Prevent duplicate key addition
            if (null != HttpContext.Current.Cache[CacheItemKey]) return;

            HttpContext.Current.Cache.Add(CacheItemKey, "WS", null, DateTime.MaxValue,
                TimeSpan.FromMinutes(1), CacheItemPriority.NotRemovable,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }


        /// <summary>
        /// Callback method which gets invoked whenever the cache entry expires.
        /// We can do our "service" works here.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        public void CacheItemRemovedCallback(
            string key,
            object value,
            CacheItemRemovedReason reason) {
            Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());

            // Do the service works
            DoWork();

            // We need to register another cache item which will expire again in one
            // minute. However, as this callback occurs without any HttpContext, we do not
            // have access to HttpContext and thus cannot access the Cache object. The
            // only way we can access HttpContext is when a request is being processed which
            // means a webpage is hit. So, we need to simulate a web page hit and then 
            // add the cache item.
            HitPage();
        }

        /// <summary>
        /// Hits a local webpage in order to add another expiring item in cache
        /// </summary>
        private void HitPage() {
            var client = new WebClient();

            try {
                CallbackPageUrl = WebConfigurationManager.AppSettings["CallbackPageUrl"];
                var uri = new Uri(CallbackPageUrl);
                client.DownloadData(uri);

            }
            catch (Exception) {
                //Ignore
            }
        }

        /// <summary>
        /// Asynchronously do the 'service' works
        /// </summary>
        private void DoWork() {
            Debug.WriteLine("Begin DoWork...");

            ExecuteQueuedJobs();

            Debug.WriteLine("End DoWork...");
        }


        #endregion

        #region Jobs

        private void RegisterJobs()
        {
            _syncStockHistoricalDataJob = new SyncStockHistoricalDataJob();
            _syncStockHistoricalDataJob.SubscribeSyncDataProgressEvent(SyncDataProgress);
            _syncStockHistoricalDataJob.Started += new EventHandler(SyncStockHistoricalDataJobStarted);
            _syncStockHistoricalDataJob.Stopped += new EventHandler(SyncStockHistoricalDataJobStopped);
        }

        private void SyncStockHistoricalDataJobStopped(object sender, EventArgs e)
        {
            StopJob(_syncStockHistoricalDataJob.JobKey);
        }

        private void SyncStockHistoricalDataJobStarted(object sender, EventArgs e)
        {
            StartJob(_syncStockHistoricalDataJob.JobKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private void SyncDataProgress(SyncDataProgressEventArgs args)
        {
            var jobAttrs = JobsHelper.Current.GetJobAttrs(_syncStockHistoricalDataJob.JobKey);
            if(jobAttrs == null)
                jobAttrs = new JobAttrs(_syncStockHistoricalDataJob.JobKey);

            jobAttrs.IsRunning = true;
            jobAttrs.Progress = args.Progress;

            JobsHelper.Current.SetJobAttrs(jobAttrs);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteQueuedJobs()
        {
            if(_syncStockHistoricalDataJob == null)
                RegisterJobs();

            var key = _syncStockHistoricalDataJob.JobKey;
            if (DateTime.Now.Hour > 25)
            {
                if (!IsJobStarted(key))
                {
                    if (
                        !_syncStockHistoricalDataJob.LastRunDate.ToShortDateString().Equals(
                            DateTime.Today.ToShortDateString()))
                    {
                        _syncStockHistoricalDataJob.Start();
                    }
                }
            }
        }

        private bool IsJobStarted(string key)
        {
            var jobAttrs = JobsHelper.Current.GetJobAttrs(key);

            if (jobAttrs != null)
            {
                return jobAttrs.IsRunning;
            }

            return false;
        }

        private void StartJob(string jobKey)
        {
            var jobAttrs = new JobAttrs(jobKey);
            jobAttrs.IsRunning = true;
            JobsHelper.Current.SetJobAttrs(jobAttrs);
        }

        private void StopJob(string jobKey)
        {
            var jobAttrs = new JobAttrs(jobKey);
            jobAttrs.IsRunning = false;
            JobsHelper.Current.SetJobAttrs(jobAttrs);
        }


        #endregion

    }
}