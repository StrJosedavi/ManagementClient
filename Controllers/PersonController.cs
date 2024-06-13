using Microsoft.AspNetCore.Mvc;
using WassamaraManagement.Domain.Enums;
using WassamaraManagement.DTOs;
using WassamaraManagement.Services.Interfaces;

namespace WassamaraManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService clienteService)
        {
            _personService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personService.Create(personDto);
            
            return Ok(new { Message = "Pessoa Criada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personService.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(new { Person = person });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto PersonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personService.Update(id, PersonDto);

            return Ok( new { Message = "Pessoa Atualizada com sucesso!"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.Delete(id);

            return Ok("Pessoa Deletada com sucesso!");
        }
    }
}
