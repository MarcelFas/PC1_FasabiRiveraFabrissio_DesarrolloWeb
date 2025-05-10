using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace API.Controllers 
{
    public class CanchasController : Controller
    {
        private readonly AppDbContext _context;

        public CanchasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Canchas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cancha = await _context.Canchas.FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
                return NotFound();

            return View(cancha);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Tipo,Ubicacion")] Cancha cancha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cancha);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
                return NotFound();

            return View(cancha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Tipo,Ubicacion")] Cancha cancha)
        {
            if (id != cancha.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanchaExists(cancha.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cancha);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cancha = await _context.Canchas.FirstOrDefaultAsync(m => m.Id == id);
            if (cancha == null)
                return NotFound();

            return View(cancha);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha != null)
                _context.Canchas.Remove(cancha);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanchaExists(int id)
        {
            return _context.Canchas.Any(e => e.Id == id);
        }
    }
}
