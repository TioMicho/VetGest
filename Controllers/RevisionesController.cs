using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetGest.Data;
using VetGest.Models;

namespace VetGest.Controllers
{
    public class RevisionesController : Controller
    {
        private readonly VetGestContext _context;
        private readonly UserManager<Usuario> _userManager;

        public RevisionesController(VetGestContext context,UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Revisiones
        public async Task<IActionResult> Index(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<Revision> revisiones = new List<Revision>();
            revisiones = await _context.Revisiones.Include(p => p.Caso).Where(u => u.UsuarioId == usuarioId).Where(p => p.CasoID == id).ToListAsync();

            return View(revisiones);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Revisiones.ToListAsync());
        //}

        // GET: Revisiones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revision = await _context.Revisiones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (revision == null)
            {
                return NotFound();
            }

            return View(revision);
        }

        // GET: Revisiones/Create
        public IActionResult Create(Guid? id)
        {

            if (id == null)
            {
                string usuarioId = _userManager.GetUserId(HttpContext.User);
                ViewBag.Casos = new SelectList(_context.Casos.Where(c => c.UsuarioId == usuarioId), "ID", "CasoN");
            }
            ViewBag.CasoID = id;

            return View();
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Revisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CasoID,Fecha,Peso,Temperatura,EstadoCorporal,TiempoLlenadoCapilar,Hidratacion,FrecuenciaRespiratoria,FrecuenciaCardiaca,AllazgosClinicos,RecomendacionesMedicacion,FechaProximaCita")] Revision revision)
        {
            if (ModelState.IsValid)
            {
                revision.ID = Guid.NewGuid();
                revision.Fecha = DateTime.Now;
                revision.UsuarioId = _userManager.GetUserId(HttpContext.User);
                _context.Add(revision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Revisiones", new { @id = revision.CasoID });
            }
            return View(revision);
        }

        // GET: Revisiones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revision = await _context.Revisiones.FindAsync(id);
            if (revision == null)
            {
                return NotFound();
            }
            return View(revision);
        }

        // POST: Revisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CasoID,Fecha,Peso,Temperatura,EstadoCorporal,TiempoLlenadoCapilar,Hidratacion,FrecuenciaRespiratoria,FrecuenciaCardiaca,AllazgosClinicos,RecomendacionesMedicacion,FechaProximaCita")] Revision revision)
        {
            if (id != revision.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    revision.UsuarioId = _userManager.GetUserId(HttpContext.User);
                    _context.Update(revision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevisionExists(revision.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Revisiones", new { @id = revision.CasoID });
            }
            return View(revision);
        }

        // GET: Revisiones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revision = await _context.Revisiones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (revision == null)
            {
                return NotFound();
            }

            return View(revision);
        }

        // POST: Revisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var revision = await _context.Revisiones.FindAsync(id);
            _context.Revisiones.Remove(revision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Revisiones", new { @id = revision.CasoID });
        }

        private bool RevisionExists(Guid id)
        {
            return _context.Revisiones.Any(e => e.ID == id);
        }
    }
}
