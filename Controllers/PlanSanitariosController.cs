using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetGest.Data;
using VetGest.Models;

namespace VetGest.Controllers
{
    public class PlanSanitariosController : Controller
    {
        private readonly VetGestContext _context;

        public PlanSanitariosController(VetGestContext context)
        {
            _context = context;
        }

        // GET: PlanSanitarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanSanitarios.ToListAsync());
        }

        // GET: PlanSanitarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planSanitario = await _context.PlanSanitarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planSanitario == null)
            {
                return NotFound();
            }

            return View(planSanitario);
        }

        // GET: PlanSanitarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanSanitarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UsuarioId,PacienteID,Fecha,VacunaAntiparasitario,FechaRefuerzo")] PlanSanitario planSanitario)
        {
            if (ModelState.IsValid)
            {
                planSanitario.ID = Guid.NewGuid();
                _context.Add(planSanitario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planSanitario);
        }

        // GET: PlanSanitarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planSanitario = await _context.PlanSanitarios.FindAsync(id);
            if (planSanitario == null)
            {
                return NotFound();
            }
            return View(planSanitario);
        }

        // POST: PlanSanitarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,UsuarioId,PacienteID,Fecha,VacunaAntiparasitario,FechaRefuerzo")] PlanSanitario planSanitario)
        {
            if (id != planSanitario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planSanitario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanSanitarioExists(planSanitario.ID))
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
            return View(planSanitario);
        }

        // GET: PlanSanitarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planSanitario = await _context.PlanSanitarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planSanitario == null)
            {
                return NotFound();
            }

            return View(planSanitario);
        }

        // POST: PlanSanitarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var planSanitario = await _context.PlanSanitarios.FindAsync(id);
            _context.PlanSanitarios.Remove(planSanitario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanSanitarioExists(Guid id)
        {
            return _context.PlanSanitarios.Any(e => e.ID == id);
        }
    }
}
