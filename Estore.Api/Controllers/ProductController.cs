using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estore.Application;
using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        

        public ProductController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneProductQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromForm] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<ProductController>/5
        [HttpPut()]
        public void Put([FromForm] UpdateProductDto dto, [FromServices] IUpdateProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id,[FromServices] IDeleteProductCommand command )
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
