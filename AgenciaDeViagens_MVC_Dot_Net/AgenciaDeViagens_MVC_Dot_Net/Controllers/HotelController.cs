using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViagens_MVC_Dot_Net.Models;

namespace AgenciaDeViagens_MVC_Dot_Net.Controllers
{
    public class HotelController : Controller
    {
        private readonly AgenciaDBContext _context;

        public HotelController(AgenciaDBContext context)
        {
            _context = context;
        }

        // GET: Hotel
        public IActionResult Index()
                        {
                              return View(_context.Hotel.ToList());
                        }

                        // GET: Hotel/Details/5
                        public IActionResult Details(int? id)
                        {
                            if (id == null || _context.Hotel == null)
                            {
                                return NotFound();
                            }

                            var hotel = _context.Hotel
                                .FirstOrDefault(m => m.HotelId == id);
                            if (hotel == null)
                            {
                                return NotFound();
                            }

                            return View(hotel);
                        }

                        // GET: Hotel/Create
                        public IActionResult Create()
                        {
                            return View();
                        }

                        // POST: Hotel/Create
                        [HttpPost]
                        public IActionResult Create([Bind("HotelId,LocalHotel,Descricao,ValorHospedagem")] Hotel hotel)
                        {
                            if (ModelState.IsValid)
                            {
                                _context.Add(hotel);
                                _context.SaveChanges();
                                return RedirectToAction(nameof(Index));
                            }
                            return View(hotel);
                        }

                        // GET: Hotel/Edit/5
                        public IActionResult Edit(int? id)
                        {
                            if (id == null || _context.Hotel == null)
                            {
                                return NotFound();
                            }

                            var hotel = _context.Hotel.FindAsync(id);
                            if (hotel == null)
                            {
                                return NotFound();
                            }
                            return View(hotel);
                        }

                        // POST: Hotel/Edit/5
                        [HttpPost]
                        public IActionResult Edit(int id, [Bind("HotelId,LocalHotel,Descricao,ValorHospedagem")] Hotel hotel)
                        {
                            if (id != hotel.HotelId)
                            {
                                return NotFound();
                            }

                            if (ModelState.IsValid)
                            {
                                try
                                {
                                    _context.Update(hotel);
                                    _context.SaveChanges();
                                }
                                catch (DbUpdateConcurrencyException)
                                {
                                    if (!HotelExists(hotel.HotelId))
                                    {
                                        return NotFound();
                                    }
                                    else
                                    {
                                        throw;
                                    }
                                }
                                return RedirectToAction(nameof(Index));
                            }
                            return View(hotel);
                        }

                        // GET: Hotel/Delete/5
                        public IActionResult Delete(int? id)
                        {
                            if (id == null || _context.Hotel == null)
                            {
                                return NotFound();
                            }

                            var hotel = _context.Hotel
                                .FirstOrDefault(m => m.HotelId == id);
                            if (hotel == null)
                            {
                                return NotFound();
                            }

                            return View(hotel);
                        }

                        // POST: Hotel/Delete/5
                        [HttpPost, ActionName("Delete")]
                        public IActionResult DeleteConfirmed(int id)
                        {
                            if (_context.Hotel == null)
                            {
                                return Problem("Entity set 'AgenciaDBContext.Hotel'  is null.");
                            }
                            var hotel = _context.Hotel.Find(id);
                            if (hotel != null)
                            {
                                _context.Hotel.Remove(hotel);
                            }

                            _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        private bool HotelExists(int id)
                        {
                          return _context.Hotel.Any(e => e.HotelId == id);
                        }
    }
}
