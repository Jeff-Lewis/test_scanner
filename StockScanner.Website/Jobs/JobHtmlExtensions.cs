using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StockScanner.Website.Jobs
{
    public static class JobHtmlExtensions
    {
        public static string RenderJobProgressBar(this HtmlHelper helper, string jobKey, string controller, string action)
        {
            var script = new StringBuilder();
            // Start script
            script.AppendLine("<script type=\"text/javascript\">");
            script.AppendLine("$(function () {");

            // Send an AJAX request every 5s to poll for changes and update the UI
            // example with jquery:
            script.AppendFormat("var pbar = $('#{0}');", jobKey);
            script.AppendLine("pbar.progressbar({ value: 0 });  setTimeout(updateProgress, 500);  });");

    
            /*

            $(function() {
                $("#progressbar").progressbar({ value: 0 });
                setTimeout(updateProgress, 500);
                });

                function updateProgress() {
                var progress;
                progress = $("#progressbar")
                .progressbar("option","value");
                if (progress < 100) {
                    $("#progressbar")
                    .progressbar("option", "value", progress + 1);
                    setTimeout(updateProgress, 500);
                }
            }

            */

            // End script
            script.AppendLine("});");

            script.AppendLine("</script>");
            script.AppendFormat("<div id=\"{0}\"></div>", jobKey);
            return string.Empty;
        }
    }
}