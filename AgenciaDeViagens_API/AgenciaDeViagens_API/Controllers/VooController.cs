using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public VooController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Voo - LISTA TODOS OS Voo
        [HttpGet]
        public IEnumerable<Voo> GetVoos()
        {
            return _context.Voo;
        }

        //GET: api/Voo/id - LISTA DE Voo POR ID
        [HttpGet("{id}")]
        public IActionResult GetVooPorId(int id)
        {
            Voo voo = _context.Voo.SingleOrDefault(modelo => modelo.VooId == id);
            if (voo == null)
            {
                return NotFound();
            }
            return new ObjectResult(voo);
        }

        //CRIA UM NOVO Voo
        [HttpPost]
        public IActionResult CriarVoo(Voo item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Voo.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetVoo", new { id = item.ID }, item);
        }

        //ATUALIZA UM Voo EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaVoo(int id, Voo item)
        {
            if (id != item.VooId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM Voo POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaVoo(int id)
        {
            var voo = _context.Voo.SingleOrDefault(m => m.VooId == id);

            if (voo == null)
            {
                return BadRequest();
            }

            _context.Voo.Remove(voo);
            _context.SaveChanges();
            return Ok(voo);
        }
    }
}
