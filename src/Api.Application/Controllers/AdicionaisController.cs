using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.AdicionalService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisController : ControllerBase
    {
        private IAdicionalService _service;

        public AdicionaisController(IAdicionalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { return Ok(await _service.GetAll()); }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetAdicionalById")]
        public async Task<ActionResult> Get(long id) 
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { return Ok(await _service.Get(id)); }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Adicional adicional) 
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try 
            {
                var result = await _service.Post(adicional);
                if (result != null) 
                {
                    return Created(new Uri(Url.Link("GetAdicionalById", new { id = result.Id, })), result);
                } else { return BadRequest(); }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}