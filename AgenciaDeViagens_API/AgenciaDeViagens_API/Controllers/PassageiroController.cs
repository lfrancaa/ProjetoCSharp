using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public PassageiroController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Passageiro - LISTA TODOS OS PASSAGEIROS
        [HttpGet]
        public IEnumerable<Passageiro>GetPassageiros()
        {
            return _context.Passageiro;
        }

        //GET: api/Passageiro/id - LISTA DE PASSAGEIROS POR ID
        [HttpGet("{id}")]
        public IActionResult GetPassageiroPorId(int id)
        {
            Passageiro passageiro = _context.Passageiro.SingleOrDefault(modelo => modelo.PassageiroId == id);
            if (passageiro == null)
            {
                return NotFound();
            }
            return new ObjectResult(passageiro);
        }

        //CRIA UM NOVO PASSAGEIRO
        [HttpPost]
        public IActionResult CriarPassageiro(Passageiro item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Passageiro.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetPassageiro", new { id = item.ID }, item);
        }

        //ATUALIZA UM PASSAGEIRO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaPassageiro(int id, Passageiro item)
        {
            if (id != item.PassageiroId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM PASSAGEIRO POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaPassageiro(int id)
        {
            var passageiro = _context.Passageiro.SingleOrDefault(m => m.PassageiroId == id);

            if (passageiro == null)
            {
                return BadRequest();
            }

            _context.Passageiro.Remove(passageiro);
            _context.SaveChanges();
            return Ok(passageiro);
        }
    }
}
