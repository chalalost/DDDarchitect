using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using DDDarchitect.Domain.DomainModel.EventDomainModel.Queries;
using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDDarchitect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public CategoryController(
            IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetMultiCategoryQuery(),
                CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("getCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(string categoryId)
        {
            if (ModelState.IsValid)
            {
                var result = await _queryProcessor
                    .ProcessAsync(
                    new GetCategoryQuery(new CategoryId(categoryId)),
                    CancellationToken.None);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
