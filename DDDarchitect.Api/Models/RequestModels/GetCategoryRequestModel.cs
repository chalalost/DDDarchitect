using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDarchitect.Api.Models.RequestModels
{
    public class GetCategoryRequestModel
    {
        public CategoryId CategoryId { get; set; }
    }
}
