using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Interfaces.Queries
{
    public interface IDomainQuery<TParams> 
        where TParams:class 
    {
        TParams Parameters { get; }
    }
}
