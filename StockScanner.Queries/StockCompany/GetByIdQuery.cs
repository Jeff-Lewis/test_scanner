using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Queries;

namespace StockScanner.Queries.StockCompany
{
    public class GetByIdQuery: IDomainQuery<GetByIdParams>
    {
        public GetByIdQuery(GetByIdParams parameters)
        {
            Parameters = parameters;
        }

        public GetByIdParams Parameters { get; private set; }
    }
}
