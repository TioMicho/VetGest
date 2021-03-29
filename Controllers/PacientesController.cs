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
    public class PacientesController : Controller
    {
        private readonly VetGestContext _context;
        private readonly UserManager<Usuario> _userManager;
        public PacientesController(VetGestContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pacientes
        //public async Task<IActionResult> Index()
        //{
        //    string usuarioId = _userManager.GetUserId(HttpContext.User);
        //    return View(await _context.Pacientes.Where(u => u.UsuarioId == usuarioId).ToListAsync());
        //}

        public async Task<IActionResult> Index(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            List<Paciente> pacientes = new List<Paciente>();
            if (id == null)
            {
                pacientes = await _context.Pacientes.Where(u => u.UsuarioId == usuarioId).ToListAsync();
            }
            else
            {
                pacientes = await _context.Pacientes.Where(u => u.UsuarioId == usuarioId).Where(p => p.ClienteID == id).ToListAsync();
            }
            return View(pacientes);
        }
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Pacientes/Create

        public IActionResult Create(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ClienteID = id;
            return View();
        }        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteID,Nombre,FechaNacimiento,Raza,Especie,Pelaje,Sexo,Chip")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.ID = Guid.NewGuid();
                paciente.UsuarioId = _userManager.GetUserId(HttpContext.User);
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Pacientes", new { @id = paciente.ClienteID });
            }
            return View(paciente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,ClienteID,Nombre,FechaNacimiento,Raza,Especie,Pelaje,Sexo,Chip")] Paciente paciente)
        {
            if (id != paciente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paciente.UsuarioId = _userManager.GetUserId(HttpContext.User);
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Pacientes", new { @id = paciente.ClienteID });
            }
            return View(paciente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Pacientes", new { @id = paciente.ClienteID });
        }

        private bool PacienteExists(Guid id)
        {
            return _context.Pacientes.Any(e => e.ID == id);
        }
    }
}
