using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTWithASPNET.Model;
using RESTWithASPNET.Services;

namespace RESTWithASPNET.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {

        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.findAll());
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.findById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.create(person));
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody]Person person)
        {

            if (person == null) return BadRequest();
            return new ObjectResult(_personService.update(person));
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.delete(id);
            return NoContent();
        }
    }
}
