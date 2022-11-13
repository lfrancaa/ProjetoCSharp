using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public PassagemController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Passagem - LISTA TODOS OS Passagem
        [HttpGet]
        public IEnumerable<Passagem> GetPassagems()
        {
            return _context.Passagem;
        }

        //GET: api/Passagem/id - LISTA DE Passagem POR ID
        [HttpGet("{id}")]
        public IActionResult GetPassagemPorId(int id)
        {
            Passagem passagem = _context.Passagem.SingleOrDefault(modelo => modelo.PassagemId == id);
            if (passagem == null)
            {
                return NotFound();
            }
            return new ObjectResult(passagem);
        }

        //CRIA UM NOVO Passagem
        [HttpPost]
        public IActionResult CriarPassagem(Passagem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Passagem.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetPassagem", new { id = item.ID }, item);
        }

        //ATUALIZA UM Passagem EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaPassagem(int id, Passagem item)
        {
            if (id != item.PassagemId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM Passagem POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaPassagem(int id)
        {
            var passagem = _context.Passagem.SingleOrDefault(m => m.PassagemId == id);

            if (passagem == null)
            {
                return BadRequest();
            }

            _context.Passagem.Remove(passagem);
            _context.SaveChanges();
            return Ok(passagem);
        }
    }
}
