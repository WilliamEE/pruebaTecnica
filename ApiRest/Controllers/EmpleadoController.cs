using BusinessModel.Services;
using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        EmpleadoService EmpleadoService;

        public EmpleadoController(ProjectDbContext context)
        {
            EmpleadoService = new EmpleadoService(context);
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<IEnumerable<Empleado>> Get()
        {
            return await EmpleadoService.Get();
        }

        // GET: api/<EmpleadoController>/idEmpleado
        [HttpGet("{IdEmpleado}")]
        public async Task<Empleado> Get(int IdEmpleado)
        {
            return await EmpleadoService.GetById(IdEmpleado);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<ActionResult<Empleado>> Post([FromBody] Empleado Empleado)
        {
            try
            {
                await EmpleadoService.Save(Empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleado Empleado)
        {
            try
            {
                await EmpleadoService.Update(id, Empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await EmpleadoService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }
    }
}
