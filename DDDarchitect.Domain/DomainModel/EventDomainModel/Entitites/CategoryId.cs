using Microservice.Framework.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class CategoryId : Identity<CategoryId>
    {
        public CategoryId(string value) : base(value)
        {

        }
    }
}
