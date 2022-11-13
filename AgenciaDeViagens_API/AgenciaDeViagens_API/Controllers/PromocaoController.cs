using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public PromocaoController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Promocao - LISTA TODOS AS Promocao
        [HttpGet]
        public IEnumerable<Promocao> GetPromocaos()
        {
            return _context.Promocao;
        }

        //GET: api/Promocao/id - LISTA DE Promocao POR ID
        [HttpGet("{id}")]
        public IActionResult GetPromocaoPorId(int id)
        {
            Promocao promocao = _context.Promocao.SingleOrDefault(modelo => modelo.PromocaoId == id);
            if (promocao == null)
            {
                return NotFound();
            }
            return new ObjectResult(promocao);
        }

        //CRIA UM NOVO Promocao
        [HttpPost]
        public IActionResult CriarPromocao(Promocao item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Promocao.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetPromocao", new { id = item.ID }, item);
        }

        //ATUALIZA UM Promocao EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaPromocao(int id, Promocao item)
        {
            if (id != item.PromocaoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM Promocao POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaPromocao(int id)
        {
            var promocao = _context.Promocao.SingleOrDefault(m => m.PromocaoId == id);

            if (promocao == null)
            {
                return BadRequest();
            }

            _context.Promocao.Remove(promocao);
            _context.SaveChanges();
            return Ok(promocao);
        }
    }
}
