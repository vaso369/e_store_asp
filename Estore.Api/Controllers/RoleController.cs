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
    public class RoleController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public RoleController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRolesQuery query)
        {
            return Ok(executor.ExecuteQuery(query,search));
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] RoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<RoleController>/5
        [HttpPut()]
        public void Put([FromBody] RolePutDto dto, [FromServices] IUpdateRoleCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
