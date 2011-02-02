using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockScanner.Website.JqGrid.Models;
using StockScanner.Website.JqGrid.Repositories;

namespace StockScanner.Website.JqGrid.Builders
{

    public class JqGridStockBuilder : IJqGridBuilder<IJqGridStockModel>
    {
        private JqGridStockRepository repository = null;
        public JqGridStockBuilder()
        {
            repository = new JqGridStockRepository();
        }

        public string BuildGrid(string gridId, string caption, string selectUrl, int pageSize)
        {
            return new Grid(gridId)
                .setCaption(".")
                .addColumn(new Column("Id").setLabel("StockId").setHidden(true))
                .addColumn(new Column("Ticker").setWidth(70))
                .addColumn(new Column("Name").setLabel("Company Name").setWidth(230))
                .addColumn(new Column("IndustryName").setLabel("Industry").setWidth(230)
                               .setSearchType(Searchtype.select).setSearchTerms(repository.GetIndustryNames()))
                .addColumn(new Column("ExchangeName").setLabel("Sector").setWidth(160)
                               .setSearchType(Searchtype.select).setSearchTerms(repository.GetSectorNames()))
                .addColumn(new Column("IndustryId").setHidden(true))
                .addColumn(new Column("SectorId").setHidden(true))
                .setUrl(selectUrl)
                .setAutoWidth(true)
                .setRowNum(pageSize)
                .setRowList(new int[] {10, 15, 20, 50})
                .setViewRecords(true)
                .setPager("pager")
                .setSearchToolbar(true)
                .setSearchClearButton(true)
                .setToolbar(true)
                .ToString();
        }
    }
}