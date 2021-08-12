using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Muinicipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        public IMunicipioService _service { get; set; }
        
        public MunicipiosController(IMunicipioService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetMunicipioWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetTask(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("Complete/{id}")]
        public async Task<ActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetCompleteById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("byIBGE/{codigoIBGE}")]
        public async Task<ActionResult> GetCompleteByIBGE(int codigoIBGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetCompleteByIBGE(codigoIBGE);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MunicipioDtoCreate dtoCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreated);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetMunicipioWithId", new {id = result.Id})), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MunicipioDtoUpdate dtoUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(dtoUpdated);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                 return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            
            }
        }
        
    }
}
