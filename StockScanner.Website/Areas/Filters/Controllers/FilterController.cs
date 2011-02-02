using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StockScanner.Website.Areas.Filters.Controllers
{
    public class FilterController : SMController
    {

        //
        // GET: /Filters/Filter/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FilterDetails(int? id)
        {
            return View();
        }
        
    }
}
