using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chiyu.DTO;
using Chiyu.Helpers;
using Chiyu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OCController : ApiControllerBase
    {
        private readonly IOCService _service;

        public OCController(IOCService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsTreeView()
        {
            var ocs = await _service.GetAllAsTreeView();
            return Ok(ocs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTerminal310409()
        {
            var ocs = await _service.GetAllTerminal310409();
            return Ok(ocs);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroup104574()
        {
            var ocs = await _service.GetAllGroup104574();
            return Ok(ocs);
        }
        

        [HttpGet("{OCname}")]
        public async Task<IActionResult> GetUserByOCname(string OCname)
        {
            var result = await _service.GetUserByOCname(OCname);
            return Ok(result);
        }

        [HttpGet("{ocID}")]
        public async Task<IActionResult> GetUserByOcID(int ocID)
        {
            var result = await _service.GetUserByOcID(ocID);
            return Ok(result);
        }

        [HttpGet("{groupID}/{min}/{max}")]
        public async Task<IActionResult> GetResultByGroup(int groupID , DateTime min , DateTime max)
        {
            var result = await _service.GetResultByGroup(groupID , min , max);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> MappingRangeUserOC(Group_TeminalDto OcUserDto)
        {
            var result = await _service.MappingRangeUserOC(OcUserDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return StatusCodeResult(await _service.DeleteAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetWithPaginationsAsync(PaginationParams paramater)
        {
            return Ok(await _service.GetWithPaginationsAsync(paramater));
        }

    }
}
