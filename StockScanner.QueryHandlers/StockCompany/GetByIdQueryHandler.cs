using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockScanner.Interfaces.DomainRepositories;
using StockScanner.Interfaces.QueryHandlers;
using StockScanner.Queries.StockCompany;

namespace StockScanner.QueryHandlers.StockCompany
{
    public class GetByIdQueryHandler : IDomainQueryHandler<GetByIdQuery, GetByIdParams>
    {
        private IDomainQueryRepository _repository;

        public GetByIdQueryHandler(IDomainQueryRepository repository)
        {
            _repository = repository;
        }

        public TResult HandleQuery<TResult>(GetByIdQuery query) where TResult:class
        {
            return _repository.StockCompany_GetById(query.Parameters.Id) as TResult;
        }
    }
}
