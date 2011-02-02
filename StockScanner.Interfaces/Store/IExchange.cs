using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Interfaces.Store
{
    public interface IExchange
    {
        Int32 Id { get; set; }

        String Name { get; set; }
    }
}
