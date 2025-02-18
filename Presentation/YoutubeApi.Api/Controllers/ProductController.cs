﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Products.Queries.GetAllProducts;


namespace YoutubeApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest { });

            return Ok(response);
        }
    }
}