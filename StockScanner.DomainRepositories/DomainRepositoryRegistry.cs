using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.DomainRepositories;
using StructureMap.Configuration.DSL;

namespace StockScanner.DomainRepositories
{
    public class DomainRepositoryRegistry: Registry
    {
        public DomainRepositoryRegistry()
        {
            For<IDomainQueryRepository>().Use<DomainQueryRepository>();
            For<IDomainCommandRepository>().Use<DomainCommandRepository>();
        }
    }
}
