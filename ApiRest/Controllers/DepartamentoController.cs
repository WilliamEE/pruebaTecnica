using BusinessModel.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AfpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        DepartamentoService DepartamentoService;

        public DepartamentoController(ProjectDbContext context)
        {
            DepartamentoService = new DepartamentoService(context);
        }
        // GET: api/<DepartamentoController>
        [HttpGet]
        public async Task<IEnumerable<Departamento>> Get()
        {
            return await DepartamentoService.Get();
        }

        // GET: api/<EmpleadoController>/idEmpleado
        [HttpGet("{IdDepartamento}")]
        public async Task<IEnumerable<Empleado>> Get(int IdDepartamento)
        {
            return await DepartamentoService.GetEmpleadosByIdDepartamento(IdDepartamento);
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public async Task<ActionResult<Departamento>> Post([FromBody] Departamento Departamento)
        {
            try 
            {
                await DepartamentoService.Save(Departamento);
            }
            catch(Exception ex) 
            { 
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Departamento Departamento)
        {
            try
            {
                await DepartamentoService.Update(id, Departamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await DepartamentoService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }
    }
}
