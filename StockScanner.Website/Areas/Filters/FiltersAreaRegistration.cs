using System.Web.Mvc;

namespace StockScanner.Website.Areas.Filters
{
    public class FiltersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Filters";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            
            context.MapRoute(
                "Filter_Details",
                "Filters/Filter/{id}",
                new { controller = "filter", action = "FilterDetails", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Filters_default",
                "Filters/{action}/{id}",
                new {controller = "filter", action = "Index", id = UrlParameter.Optional }
            );
             
        }
    }
}
