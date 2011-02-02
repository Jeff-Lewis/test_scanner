using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace StockScanner.Website.StructureMap
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new ApplicationRegistry());
                //x.AddRegistry(new DomainRegistry());
            });

            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}