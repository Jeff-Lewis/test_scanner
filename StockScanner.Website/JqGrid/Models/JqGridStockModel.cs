using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StockScanner.Website.JqGrid.Models
{
    public class JqGridStockModel: IJqGridStockModel
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string IndustryName { get; set; }
        public string ExchangeName { get; set; }

        public int? ExchangeId { get; set; }

        public int? IndustryId { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}