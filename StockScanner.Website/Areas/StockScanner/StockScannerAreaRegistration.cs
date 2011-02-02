using System.Web.Mvc;

namespace StockScanner.Website.Areas.StockScanner
{
    public class StockScannerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "StockScanner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "StockScanner_default",
                "StockScanner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
