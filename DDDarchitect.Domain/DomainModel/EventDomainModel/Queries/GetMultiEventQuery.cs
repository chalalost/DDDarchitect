using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using Microservice.Framework.Persistence.EFCore.Queries.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDarchitect.Domain.DomainModel.EventDomainModel.Queries
{
    public class GetMultiEventQuery
        : EFCoreCriteriaDomainQuery<Event>, IQuery<IEnumerable<Event>>
    {
        public GetMultiEventQuery(CategoryId categoryId)
        {
            CategoryId = categoryId;
        }

        public CategoryId CategoryId { get; }

        protected override void OnBuildDomainCriteria(EFCoreDomainCriteria domainCriteria)
        {
        }
    }

    public class GetMultiEventQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Event>, IQueryHandler<GetMultiEventQuery, IEnumerable<Event>>
    {
        #region cto

        public GetMultiEventQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<IEnumerable<Event>> ExecuteQueryAsync(
            GetMultiEventQuery query,
            CancellationToken cancellationToken)
        {
            return FindAll(query);
        }

        #endregion
    }
}
