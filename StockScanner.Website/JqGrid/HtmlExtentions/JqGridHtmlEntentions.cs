using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockScanner.Interfaces.Store;
using StockScanner.Website.JqGrid.Builders;

namespace StockScanner.Website.JqGrid.HtmlExtentions
{
    public static class JqGridHtmlEntentions
    {
        public static string RenderGrid<T>(this HtmlHelper helper, string gridId, string caption, string selectUrl, int pageSize) where T : class, INamedEntity
        {
            return new JqGridStockBuilder().BuildGrid(gridId, caption, selectUrl, pageSize);
        }
    }
}