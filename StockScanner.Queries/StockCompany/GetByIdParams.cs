using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Queries.StockCompany
{
    public class GetByIdParams
    {
        public int Id { get; private set; }

        public GetByIdParams(int id)
        {
            Id = id;
        }
    }
}
