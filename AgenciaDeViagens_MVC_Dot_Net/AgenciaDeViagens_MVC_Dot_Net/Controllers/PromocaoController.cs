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
    public class PromocaoController : Controller
    {
        private readonly AgenciaDBContext _context;

        public PromocaoController(AgenciaDBContext context)
        {
            _context = context;
        }

        // GET: Promocao
        public async Task<IActionResult> Index()
        {
              return View(await _context.Promocao.ToListAsync());
        }

        // GET: Promocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promocao == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // GET: Promocao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromocaoId,LocalViagem,Descricao,ValorViagem")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocao);
        }

        // GET: Promocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promocao == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao.FindAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            return View(promocao);
        }

        // POST: Promocao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromocaoId,LocalViagem,Descricao,ValorViagem")] Promocao promocao)
        {
            if (id != promocao.PromocaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocaoExists(promocao.PromocaoId))
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
            return View(promocao);
        }

        // GET: Promocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promocao == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // POST: Promocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promocao == null)
            {
                return Problem("Entity set 'AgenciaDBContext.Promocao'  is null.");
            }
            var promocao = await _context.Promocao.FindAsync(id);
            if (promocao != null)
            {
                _context.Promocao.Remove(promocao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocaoExists(int id)
        {
          return _context.Promocao.Any(e => e.PromocaoId == id);
        }
    }
}
