using AgenciaDeViagens_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AgenciaDBContext _context;

        public HotelController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:api/Hotel - LISTA TODOS OS Hotel
        [HttpGet]
        public IEnumerable<Hotel> GetHotels()
        {
            return _context.Hotel;
        }

        //GET: api/Hotel/id - LISTA DE Hotel POR ID
        [HttpGet("{id}")]
        public IActionResult GetHotelPorId(int id)
        {
            Hotel hotel = _context.Hotel.SingleOrDefault(modelo => modelo.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return new ObjectResult(hotel);
        }

        //CRIA UM NOVO Hotel
        [HttpPost]
        public IActionResult CriarHotel(Hotel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Hotel.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

            // return CreatedAtAction("GetHotel", new { id = item.ID }, item);
        }

        //ATUALIZA UM Hotel EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaHotel(int id, Hotel item)
        {
            if (id != item.HotelId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //APAGA UM Hotel POR ID

        [HttpDelete("{id}")]
        public IActionResult DeletaHotel(int id)
        {
            var hotel = _context.Hotel.SingleOrDefault(m => m.HotelId == id);

            if (hotel == null)
            {
                return BadRequest();
            }

            _context.Hotel.Remove(hotel);
            _context.SaveChanges();
            return Ok(hotel);
        }
    }
}
