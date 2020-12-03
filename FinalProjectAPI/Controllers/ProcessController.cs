using FinalProject.Core.ApplicationService.Services;
using FinalProject.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Process>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_processService.GetFilteredProcesses(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Process> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest("id must be greater than 0");
            }
            return _processService.ReadByIdIncludeErrors(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Process> Post([FromBody] Process process)
        {
            if (string.IsNullOrEmpty(process.ProcessName))
            {
                return BadRequest("process name must not be empty or null");
            }
            else if (_processService.CheckProcess(process) != null)
            {
                var processFound = _processService.CheckProcess(process);
                return StatusCode(218 , processFound.ProcessName + " does already exist with the id of: " + processFound.Id);
            }
            return _processService.CreateProcess(process);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Process> Put(int id, [FromBody] Process process)
        {
            if (id < 1 || id != process.Id)
            {
                return BadRequest("parameter id and error id was not the same");
            }

            return Ok(_processService.UpdateProcess(process));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Error> Delete(int id)
        {
            var process = _processService.DeleteProcess(id);
            if (process == null)
            {
                return StatusCode(404, "did not find error with: " + id);
            }
            return Ok(process);
        }
    }

}

