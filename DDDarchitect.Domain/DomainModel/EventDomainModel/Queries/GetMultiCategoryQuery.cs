using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDarchitect.Domain.DomainModel.EventDomainModel.Queries
{
    public class GetMultiCategoryQuery
        : EFCoreCriteriaDomainQuery<Category>, IQuery<IEnumerable<Category>>
    {
    }

    public class GetMultiCategoryQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Category>, IQueryHandler<GetMultiCategoryQuery, IEnumerable<Category>>
    {
        #region cto

        public GetMultiCategoryQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<IEnumerable<Category>> ExecuteQueryAsync(
            GetMultiCategoryQuery query,
            CancellationToken cancellationToken)
        {
            return FindAll(query);
        }

        #endregion
    }
}
