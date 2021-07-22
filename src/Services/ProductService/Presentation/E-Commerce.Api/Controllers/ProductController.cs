using E_Commerce.Application.Features.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ProductController> logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductDetails()
        {
            var query = new GetAllProductsQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetProduct(string slug)
        {
            logger.LogInformation($"Get product method ({slug}) processed a request.");

            var query = new GetProductQuery() { Slug = slug };
            return Ok(await mediator.Send(query));
        }
    }
}
