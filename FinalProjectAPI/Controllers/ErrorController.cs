using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Core.ApplicationService;
using FinalProject.Core.ApplicationService.Services;
using FinalProject.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        private IErrorService _errorService;

        public ErrorController(IErrorService errorService)
        {
            _errorService = errorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Error>> Get()
        {
            return _errorService.GetAllErrors();
        }

        [HttpGet("{id}")]
        public ActionResult<Error> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest("id must be greater than 0");
            }
            return _errorService.FindErrorById(id);
        }

        [HttpPost]
        public ActionResult<Error> Post([FromBody] Error error)
        {
            if (string.IsNullOrEmpty(error.ErrorDetail))
            {
                return BadRequest("error detail must not be empty or null");
            }
            else if (string.IsNullOrEmpty(error.ErrorType))
            {
                return BadRequest("error type must not be empty or null");
            }
            return _errorService.CreateError(error);
        }

        [HttpPut("{id}")]
        public ActionResult<Error> Put(int id, [FromBody] Error error)
        {
            if (id < 1 || id != error.Id)
            {
                return BadRequest("parameter id and error id was not the same");
            }
            
            return Ok(_errorService.UpdateError(error));
        }

        [HttpDelete("{id}")]
        public ActionResult<Error> Delete(int id)
        {
            var error = _errorService.DeleteError(id);
            if (error == null)
            {
                return StatusCode(404, "did not find error with: " + id);
            }
            return Ok($"Error with id {id} is Deleted");
        }
    }
}
