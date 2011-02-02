using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockScanner.Website.Jobs;
using StockScanner.Website.JqGrid;
using StockScanner.Website.JqGrid.Repositories;

namespace StockScanner.Website.Controllers
{
    public class HomeController : Controller
    {
        private JqGridStockRepository repo = new JqGridStockRepository();

        //public HomeController(IStockMonitorService service) {
        //    repo = new JqGridStockRepository();
        //}

 
        /// <summary>
        /// AJAX request, retrieves data for basic grid
        /// </summary>
        /// <param name="gridSettings">Settings received from jqGrid request</param>
        /// <returns>JSON view containing data for basic grid</returns>
        public ActionResult GridDataBasic(GridSettings gridSettings) {
            var stocks = this.repo.Get(gridSettings);
            int totalStocks = this.repo.Count(gridSettings);

            var jsonData = new {
                total = totalStocks / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = totalStocks,
                rows = (
                    from c in stocks
                    select new {
                        id = c.Id,
                        cell = new string[] { 
                                                c.Id.ToString(), 
                                                c.Ticker,
                                                c.Name,
                                                c.IndustryName,
                                                c.ExchangeName,
                                                c.ExchangeId.ToString(),
                                                c.ExchangeId.ToString()
                                            }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About() {
            return View();
        }


        public ActionResult GridSave(int id, int idnr, string firstName, string lastName)
        {
            /*
            jQueryGridModelDataContext db = new jQueryGridModelDataContext();

            Employee e = db.Employees.SingleOrDefault(p => p.ID == idnr);
            if (!(e == null))
            {
                e.FirstName = firstName;
                e.LastName = lastName;
                db.SubmitChanges();
                return Content("true");
            }
            else
            {
                return Content("false");
            }
             */
            return Content("true");
        }
    }
}
