using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Criação de Pessoa
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personService.Create(personDto);
            
            return Created();
        }

        /// <summary>
        /// Busca de Pessoa por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var person = await _personService.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(new { Person = person });
        }

        /// <summary>
        /// Busca de Pessoas por filtro
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        
        [Authorize]
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAll([FromQuery] string? cpf, [FromQuery] string? cnpj)
        {
            var person = await _personService.GetAll(cpf, cnpj);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(new { Person = person });
        }

        /// <summary>
        /// Atualização de Pessoas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PersonDto"></param>
        /// <returns></returns>
        
        [Authorize]
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

        /// <summary>
        /// Deletar Pessoas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.Delete(id);

            return Ok(new { Message = "Pessoa Deletada com sucesso!" });
        }
    }
}
