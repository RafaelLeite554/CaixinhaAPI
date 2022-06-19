using CaixinhaAPI.Model;
using CaixinhaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaixinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixinhaController : ControllerBase
    {

        private readonly ICaixinhaRepository _caixinhaRepository;
        public CaixinhaController(ICaixinhaRepository caixinhaRepository)
        {
            _caixinhaRepository = caixinhaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Ideia>> GetIdeias()
        {
            return await _caixinhaRepository.Get();
        }

        [HttpGet("(id)")]
        public async Task<ActionResult<Ideia>> GetIdeias(int id)
        {
            return await _caixinhaRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ideia>> PostIdeias([FromBody] Ideia ideia)
        {
            var newIdeia = await _caixinhaRepository.Create(ideia);
            return CreatedAtAction(nameof(GetIdeias), new { id = newIdeia.Id }, newIdeia);
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult> Delete(int id)
        {
            var ideiaToDelete = await _caixinhaRepository.Get(id);
            if(ideiaToDelete == null)
                return NotFound();

            await _caixinhaRepository.Delete(ideiaToDelete.Id);
            return NoContent();
            
        }

        [HttpPut]
        public async Task<ActionResult> PutIdeias(int id, [FromBody] Ideia ideia)
        {
            if (id == ideia.Id)
                return BadRequest();

            await _caixinhaRepository.Update(ideia);
            return NoContent();
        }


    }
}

