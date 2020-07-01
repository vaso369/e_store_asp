using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estore.Application;
using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public CategoryController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategoryDto search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }



        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<CategoryController>/5
        [HttpPut()]
        public void Put( [FromBody] CategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
