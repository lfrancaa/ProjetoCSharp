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
    public class PassageiroController : Controller
    {
        private readonly AgenciaDBContext _context;

        public PassageiroController(AgenciaDBContext context)
        {
            _context = context;
        }

        //GET:Passageiro
        public IActionResult Index()
        {
            return View(_context.Passageiro.ToList());
        }

        //GET: Passageiro/Detail/id
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = _context.Passageiro.FirstOrDefault(m => m.PassageiroId == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // GET: Passageiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: Passageiro/Create
        [HttpPost]
        public IActionResult Create([Bind("PassageiroId,Nome,Rg,Cpf,DataNascimento,Endereco,Complemento,Cep,Estado,Email,Telefone")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passageiro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(passageiro);
        }

        // GET: Passageiro/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = _context.Passageiro.Find(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            return View(passageiro);
        }

        //Post: Passageiro/Edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("PassageiroId,Nome,Rg,Cpf,DataNascimento,Endereco,Complemento,Cep,Estado,Email,Telefone")] Passageiro passageiro)
        {
            _context.Update(passageiro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

            // return View(passageiro);
        }

        //GET:Passageiro/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Passageiro == null)
            {
                return NotFound();
            }

            var passageiro = _context.Passageiro.FirstOrDefault(m => m.PassageiroId == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        //Post:Passageiro/Delete/id
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Passageiro == null)
            {
                return Problem("Entity set 'AgenciaDBContext.Passageiro'  is null.");
            }
            var passageiro = _context.Passageiro.Find(id);
            if (passageiro != null)
            {
                _context.Passageiro.Remove(passageiro);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
