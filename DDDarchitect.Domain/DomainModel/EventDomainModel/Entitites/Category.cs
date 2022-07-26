using Microservice.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites
{
    public class Category : Entity<CategoryId>
    {
        #region property
        public string CategoryName { get; set; }
        #endregion
    }
}
