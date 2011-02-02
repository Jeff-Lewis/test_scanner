using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.QueryHandlers;
using StockScanner.Queries.StockCompany;
using StockScanner.QueryHandlers.StockCompany;
using StructureMap.Configuration.DSL;

namespace StockScanner.QueryHandlers
{
    public class QueryHandlerRegistry: Registry
    {
        public QueryHandlerRegistry()
        {
            For<IDomainQueryHandler<GetByIdQuery, GetByIdParams>>().Use<GetByIdQueryHandler>();
        }
    }
}
