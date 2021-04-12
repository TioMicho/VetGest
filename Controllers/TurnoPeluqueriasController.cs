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
    public class TurnoPeluqueriasController : Controller
    {
        private readonly VetGestContext _context;
        private readonly UserManager<Usuario> _userManager;


        public TurnoPeluqueriasController(VetGestContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: TurnoPeluquerias
        public async Task<IActionResult> Index(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<TurnoPeluqueria> turnoPeluquerias = new List<TurnoPeluqueria>();
            turnoPeluquerias = await _context.TurnoPeluquerias.Include(t => t.Cliente).Include(p => p.Paciente).Where(u => u.UsuarioId == usuarioId).ToListAsync();
            //var vetGestContext = _context.TurnoPeluquerias.Include(t => t.Cliente).Include(t => t.Paciente).Where(u => u.UsuarioId == usuarioId);
            //return View(await vetGestContext.ToListAsync());
            return View(turnoPeluquerias);
        }

        // GET: TurnoPeluquerias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoPeluqueria = await _context.TurnoPeluquerias
                .Include(t => t.Cliente)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (turnoPeluqueria == null)
            {
                return NotFound();
            }

            return View(turnoPeluqueria);
        }

        // GET: TurnoPeluquerias/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "DueñoApellido");
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "ID", "ID");
            return View();
        }

        // POST: TurnoPeluquerias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UsuarioId,Fecha,ClienteID,Lugar,PacienteID,Telefono")] TurnoPeluqueria turnoPeluqueria)
        {
            if (ModelState.IsValid)
            {
                turnoPeluqueria.ID = Guid.NewGuid();
                _context.Add(turnoPeluqueria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "DueñoApellido", turnoPeluqueria.ClienteID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "ID", "ID", turnoPeluqueria.PacienteID);
            return View(turnoPeluqueria);
        }

        // GET: TurnoPeluquerias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoPeluqueria = await _context.TurnoPeluquerias.FindAsync(id);
            if (turnoPeluqueria == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "DueñoApellido", turnoPeluqueria.ClienteID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "ID", "ID", turnoPeluqueria.PacienteID);
            return View(turnoPeluqueria);
        }

        // POST: TurnoPeluquerias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,UsuarioId,Fecha,ClienteID,Lugar,PacienteID,Telefono")] TurnoPeluqueria turnoPeluqueria)
        {
            if (id != turnoPeluqueria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoPeluqueria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoPeluqueriaExists(turnoPeluqueria.ID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "DueñoApellido", turnoPeluqueria.ClienteID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "ID", "ID", turnoPeluqueria.PacienteID);
            return View(turnoPeluqueria);
        }

        // GET: TurnoPeluquerias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoPeluqueria = await _context.TurnoPeluquerias
                .Include(t => t.Cliente)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (turnoPeluqueria == null)
            {
                return NotFound();
            }

            return View(turnoPeluqueria);
        }

        // POST: TurnoPeluquerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var turnoPeluqueria = await _context.TurnoPeluquerias.FindAsync(id);
            _context.TurnoPeluquerias.Remove(turnoPeluqueria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoPeluqueriaExists(Guid id)
        {
            return _context.TurnoPeluquerias.Any(e => e.ID == id);
        }
    }
}
