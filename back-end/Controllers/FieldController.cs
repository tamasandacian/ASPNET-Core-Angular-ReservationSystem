using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class FieldController: ControllerBase
    {
        private readonly IFieldService _fieldService;
        public FieldController(IFieldService fieldService) 
        {
            _fieldService = fieldService;
        }

        [HttpGet("[action]")]
        public IActionResult GetFields()
        {
            try
            {
                var fields = _fieldService.GetListOfFields();
                return Ok(fields);
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } 
}