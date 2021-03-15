using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetGest.Models;


namespace VetGest.Data
{
    public class VetGestContext : IdentityDbContext
    {
        public VetGestContext(DbContextOptions<VetGestContext> options) : base(options)
        {
        }
        public DbSet<Caso>Casos { get; set; }
        public DbSet<Paciente>Pacientes { get; set; }
        public DbSet<PlanSanitario> PlanSanitarios { get; set; }
        public DbSet<VetGest.Models.Cliente> Cliente { get; set; }
    }
}
