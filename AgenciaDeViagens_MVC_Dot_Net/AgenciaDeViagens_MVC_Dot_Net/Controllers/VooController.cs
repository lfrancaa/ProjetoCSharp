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
    public class VooController : Controller
    {
        private readonly AgenciaDBContext _context;

        public VooController(AgenciaDBContext context)
        {
            _context = context;
        }

        // GET: Voo
        public async Task<IActionResult> Index()
        {
              return View(await _context.Voo.ToListAsync());
        }

        // GET: Voo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voo == null)
            {
                return NotFound();
            }

            var voo = await _context.Voo
                .FirstOrDefaultAsync(m => m.VooId == id);
            if (voo == null)
            {
                return NotFound();
            }

            return View(voo);
        }

        // GET: Voo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VooId,Origem,Destino,Partida,Chegada,ValorVoo,Paradas")] Voo voo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voo);
        }

        // GET: Voo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voo == null)
            {
                return NotFound();
            }

            var voo = await _context.Voo.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }
            return View(voo);
        }

        // POST: Voo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VooId,Origem,Destino,Partida,Chegada,ValorVoo,Paradas")] Voo voo)
        {
            if (id != voo.VooId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VooExists(voo.VooId))
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
            return View(voo);
        }

        // GET: Voo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voo == null)
            {
                return NotFound();
            }

            var voo = await _context.Voo
                .FirstOrDefaultAsync(m => m.VooId == id);
            if (voo == null)
            {
                return NotFound();
            }

            return View(voo);
        }

        // POST: Voo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voo == null)
            {
                return Problem("Entity set 'AgenciaDBContext.Voo'  is null.");
            }
            var voo = await _context.Voo.FindAsync(id);
            if (voo != null)
            {
                _context.Voo.Remove(voo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VooExists(int id)
        {
          return _context.Voo.Any(e => e.VooId == id);
        }
    }
}
