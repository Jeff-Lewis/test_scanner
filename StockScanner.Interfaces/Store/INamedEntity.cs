using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockScanner.Interfaces.Store
{
    public interface INamedEntity: IStoreEntity
    {
        string Name { get; set; }
    }
}
