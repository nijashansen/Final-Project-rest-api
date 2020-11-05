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
            return _errorService.FindErrorById(id);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _errorService.DeleteError(id);
        }
    }
}
