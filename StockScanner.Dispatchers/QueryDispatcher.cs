using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.Dispatchers;
using StockScanner.Interfaces.QueryHandlers;
using StructureMap;

namespace StockScanner.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public List<Interfaces.QueryHandlers.IDomainQueryHandler<TQuery, TParams>> Dispatch<TQuery, TParams>(TQuery query)
            where TQuery : Interfaces.Queries.IDomainQuery<TParams>
            where TParams : class
        {
            throw new NotImplementedException();
        }

        public TResult DispatchAndHandle<TQuery, TParams, TResult>(TQuery query)
            where TQuery : Interfaces.Queries.IDomainQuery<TParams>
            where TParams : class
            where TResult : class
        {
            TResult result = null;

            var handlers = ObjectFactory.GetAllInstances<IDomainQueryHandler<TQuery, TParams>>();
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    var res = handler.HandleQuery<TResult>(query);
                    if (res != null)
                        result = res;

                }
            }
            return result;
        }
    }
}
