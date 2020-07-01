using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estore.Application;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public LogController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

       // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch search, [FromServices] IGetLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

    }
}
