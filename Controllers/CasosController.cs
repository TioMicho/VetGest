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
    public class CasosController : Controller
    {
        //private readonly Usuario _usuario;// prueva 1
        private readonly VetGestContext _context;
        private readonly UserManager<Usuario> _userManager;
        public CasosController(VetGestContext context, UserManager<Usuario> userManager)/// prueva 1.aqui agregue  Usuario usuario
        {
            _context = context;
            _userManager = userManager;
            //_usuario = usuario; // Prueva 1. 
        }

        // GET: Casos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Casos.ToListAsync());
        //}
        public async Task<IActionResult> IndexMain(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<Caso> casos = new List<Caso>();
            //casos = await _context.Casos.Include(p => p.Paciente).Where(u => u.UsuarioId == usuarioId).ToListAsync();
            casos = await _context.Casos.Include(p => p.Paciente).Where(u => u.UsuarioId == usuarioId).Where(c =>c.Activo == true).ToListAsync();


            return View(casos);
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<Caso> casos = new List<Caso>();
            if (id == null)
            {
                casos = await _context.Casos.Include(p => p.Paciente).Where(u => u.UsuarioId == usuarioId).ToListAsync();
            }
            else
            {
                casos = await _context.Casos.Include(p => p.Paciente).Where(u => u.UsuarioId == usuarioId).Where(p => p.PacienteID == id).ToListAsync();
            }
            return View(casos);
        }


        // GET: Casos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Casos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (caso == null)
            {
                return NotFound();
            }

            return View(caso);
        }

        // GET: Casos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        public IActionResult Create(Guid? id)
        {
            if (id == null)
            {
                string usuarioId = _userManager.GetUserId(HttpContext.User);
                ViewBag.Pacientes = new SelectList(_context.Pacientes.Where(c => c.UsuarioId == usuarioId), "ID", "Nombre");
            }
            ViewBag.PacienteID = id;

            return View();
        }

        // POST: Casos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasoN,PacienteID,Fecha,MotivoConsulta")] Caso caso)
        {
   
            if (ModelState.IsValid)
            {
                caso.ID = Guid.NewGuid();
                caso.Fecha = DateTime.Now;
                caso.Activo = true;
                var usuario = await _userManager.GetUserAsync(HttpContext.User);
                caso.UsuarioId = _userManager.GetUserId(HttpContext.User);
                usuario.LocalCasoN++;
                caso.CasoN = usuario.LocalCasoN ;
                await _userManager.UpdateAsync(usuario);
                _context.Add(caso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Casos", new { @id = caso.PacienteID });
            }
            return View(caso);
        }

        // GET: Casos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Casos.FindAsync(id);
            if (caso == null)
            {
                return NotFound();
            }
            return View(caso);
        }

        // POST: Casos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CasoN,PacienteID,UsuarioId,Fecha,MotivoConsulta,Activo")] Caso caso)
        {
            if (id != caso.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    caso.UsuarioId = _userManager.GetUserId(HttpContext.User);
                    _context.Update(caso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasoExists(caso.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Casos", new { @id = caso.PacienteID });
            }
            return View(caso);
        }

        // GET: Casos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caso = await _context.Casos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (caso == null)
            {
                return NotFound();
            }

            return View(caso);
        }

        // POST: Casos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caso = await _context.Casos.FindAsync(id);
            _context.Casos.Remove(caso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Casos", new { @id = caso.PacienteID });
        }

        private bool CasoExists(Guid id)
        {
            return _context.Casos.Any(e => e.ID == id);
        }
    }
}
