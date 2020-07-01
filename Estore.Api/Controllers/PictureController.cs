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
    public class PictureController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public PictureController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET api/<PictureController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneProductPicturesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<PictureController>
        [HttpPost]
        public void Post([FromForm] NewProductPictureDto dto, [FromServices] ICreateNewPictureCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpDelete()]
        public void Delete([FromBody] IEnumerable<ProductPictureDeleteDto> dto, [FromServices] IDeleteOneProductPicturesCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
