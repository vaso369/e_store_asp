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
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public OrderController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneOrderQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpPatch("changestatus")]
        public void ChangeStatus([FromBody] ChangeOStatusDto dto, [FromServices] IUpdateOrderStatusCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
