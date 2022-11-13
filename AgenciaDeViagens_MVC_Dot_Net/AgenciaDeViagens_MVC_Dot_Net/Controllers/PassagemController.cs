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
    public class PassagemController : Controller
    {
        private readonly AgenciaDBContext _context;

        public PassagemController(AgenciaDBContext context)
        {
            _context = context;
        }

        // GET: Passagem
        public async Task<IActionResult> Index()
        {
              return View(await _context.Passagem.ToListAsync());
        }

        // GET: Passagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem
                .FirstOrDefaultAsync(m => m.PassagemId == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassagemId,Nome,NomeLocalOrigem,NomeLocalDestino,DataViagemIda,DataViagemVolta")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passagem);
        }

        // GET: Passagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            return View(passagem);
        }

        // POST: Passagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassagemId,Nome,NomeLocalOrigem,NomeLocalDestino,DataViagemIda,DataViagemVolta")] Passagem passagem)
        {
            if (id != passagem.PassagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.PassagemId))
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
            return View(passagem);
        }

        // GET: Passagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passagem == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagem
                .FirstOrDefaultAsync(m => m.PassagemId == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passagem == null)
            {
                return Problem("Entity set 'AgenciaDBContext.Passagem'  is null.");
            }
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem != null)
            {
                _context.Passagem.Remove(passagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
          return _context.Passagem.Any(e => e.PassagemId == id);
        }
    }
}
