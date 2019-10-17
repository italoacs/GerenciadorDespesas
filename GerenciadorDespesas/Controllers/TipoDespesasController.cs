using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Controllers
{
    public class TipoDespesasController : Controller
    {
        private readonly Contexto _context;

        public TipoDespesasController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoDespesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDespesas.ToListAsync());
        }

        // GET: TipoDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if (ModelState.IsValid)
            {

                TempData["Confimacao"] = tipoDespesas.Nome + " foi Cadastrado com sucesso";
                _context.Add(tipoDespesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }

        // GET: TipoDespesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            if (tipoDespesas == null)
            {
                return NotFound();
            }
            return View(tipoDespesas);
        }

        // POST: TipoDespesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if (id != tipoDespesas.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confimacao"] = tipoDespesas.Nome + " foi Atualizado com sucesso";

                    _context.Update(tipoDespesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesasExists(tipoDespesas.TipoDespesaId))
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
            return View(tipoDespesas);
        }


        // POST: TipoDespesas/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            TempData["Confimacao"] = tipoDespesas.Nome + " foi Deletado com sucesso";
            _context.TipoDespesas.Remove(tipoDespesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDespesasExists(int id)
        {
            return _context.TipoDespesas.Any(e => e.TipoDespesaId == id);
        }
    }
}
