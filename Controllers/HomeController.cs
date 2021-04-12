using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VetGest.Data;
using VetGest.Models;

namespace VetGest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VetGestContext _context;
        private readonly UserManager<Usuario> _userManager;
        public HomeController(ILogger<HomeController> logger, VetGestContext context, UserManager<Usuario> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(Guid? id)
        {
            string usuarioId = _userManager.GetUserId(HttpContext.User);
            var lista = _context.Agendas.Where(u => u.UsuarioId == usuarioId && u.Inicio == DateTime.Today.Date).ToList();
            var eventos = from le in lista
                          select new
                          {
                              id = le.AgendaID,
                              start = le.Inicio,
                              end = le.Fin,
                              text = le.Evento,
                          };
            ViewBag.eventos = Json(eventos.ToList());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
