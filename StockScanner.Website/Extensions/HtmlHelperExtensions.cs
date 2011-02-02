using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace StockScanner.Website.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="strong"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static IHtmlString SectionHeader(this HtmlHelper helper, string strong, string normal)
        {
            return helper.Raw(string.Format("<div class='header_h2'><div class='arrow'></div><div class='text'><strong>{0}</strong>{1}</div></div>",strong, normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="strong"></param>
        /// <param name="normal"></param>
        /// <param name="actionUrl"></param>
        /// <param name="actionTip"></param>
        /// <returns></returns>
        public static IHtmlString SectionHeader(this HtmlHelper helper, string strong, string normal, string actionUrl, string actionTip)
        {
            return helper.Raw(string.Format("<div class='header_h2'><div class='action'><a href='{2}' title='{3}'></a></div><div class='arrow'></div><div class='text'><strong>{0}</strong>{1}</div></div>", strong, normal, actionUrl, actionTip));
        }


        public static IHtmlString SubSectionHeader(this HtmlHelper helper, string strong, string normal)
        {
            return helper.Raw(string.Format("<div class='header_h3'><div class='arrow'></div><div class='text'><strong>{0}</strong>{1}</div></div>", strong, normal));
        }

        public static IHtmlString SubSectionHeader(this HtmlHelper helper, string strong, string normal, string actionUrl, string actionTip)
        {
            return helper.Raw(string.Format("<div class='header_h3'><div class='action'><a href='{2}' title='{3}'></a></div><div class='arrow'></div><div class='text'><strong>{0}</strong>{1}</div></div>", strong, normal, actionUrl, actionTip));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="caption"></param>
        /// <param name="actionUrl"></param>
        /// <param name="actionTip"></param>
        /// <returns></returns>
        public static IHtmlString ToggleHeader(this HtmlHelper helper, string caption, string actionUrl, string actionTip)
        {
            return helper.Raw(string.Format("<div class='toggle_header'><div class='action'><a href='{1}' title='{2}'></a></div><div class='header_start'></div><div class='header_end'></div><a href='#' class='text fadeNext'>{0}</a></div>", caption, actionUrl, actionTip));
        }

        public static IHtmlString ToggleHeader(this HtmlHelper helper, string caption)
        {
            return helper.Raw(string.Format("<div class='toggle_header'><div class='header_start'></div><div class='header_end'></div><a href='#' class='text fadeNext'>{0}</a></div>", caption));
        }

    }
}