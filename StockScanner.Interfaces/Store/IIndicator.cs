using System;

namespace StockScanner.Interfaces.Store
{
    public interface IIndicator
    {
        Int32 Id { get; set; }

        String Name { get; set; }
    }
}