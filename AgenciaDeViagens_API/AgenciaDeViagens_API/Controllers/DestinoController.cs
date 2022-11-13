using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public DestinoController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Destino - LISTA TODOS OS DESTINOS
        [HttpGet]
        public IEnumerable<Destino> GetDestinos()
        {
            return _context.Destino;
        }

        //GET: api/Destino/id - LISTA DE Destinos POR ID
        [HttpGet("{id}")]
        public IActionResult GetDestinoPorId(int id)
        {
            Destino destino = _context.Destino.SingleOrDefault(modelo => modelo.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);
        }

        //CRIA UM NOVO Destino
        [HttpPost]
        public IActionResult CriarDestino(Destino item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Destino.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetDestino", new { id = item.ID }, item);
        }

        //ATUALIZA UM Destino EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaDestino(int id, Destino item)
        {
            if (id != item.DestinoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM Destino POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaDestino(int id)
        {
            var destino = _context.Destino.SingleOrDefault(m => m.DestinoId == id);

            if (destino == null)
            {
                return BadRequest();
            }

            _context.Destino.Remove(destino);
            _context.SaveChanges();
            return Ok(destino);
        }
    }
}
