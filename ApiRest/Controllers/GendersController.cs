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
    public class GendersController : ControllerBase
    {
        GendersService gendersService;

        public GendersController(ProjectDbContext context)
        {
            gendersService = new GendersService(context);
        }
        // GET: api/<GendersController>
        [HttpGet]
        public async Task<IEnumerable<Genders>> Get()
        {
            return await gendersService.Get();
        }


        // POST api/<GendersController>
        [HttpPost]
        public async Task<ActionResult<Genders>> Post([FromBody] Genders genders)
        {
            try 
            {
                await gendersService.Save(genders);
            }
            catch(Exception ex) 
            { 
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // PUT api/<GendersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Genders genders)
        {
            try
            {
                await gendersService.Update(id, genders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }

        // DELETE api/<GendersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await gendersService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Something went Wrong! Exception: " + ex);
            }
            return Ok();
        }
    }
}
