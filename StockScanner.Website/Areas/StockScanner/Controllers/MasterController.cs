using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StockScanner.Website.Areas.StockScanner.Controllers
{
    public abstract class MasterController : Controller
    {
        //public IStockScannerService StockScannerService { get; private set; }


        protected MasterController()
        {
            //StockScannerService = service;
        }

        /// <summary>
        /// For TDD
        /// </summary>
        /// <param name="service"></param>
        //protected MasterController(IStockScannerService service)
        //{
        //    StockScannerService = service;
        //}
    }
}
