using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetGest.Models
{
    public class TurnoPeluqueria
    {
        [Key]
        public Guid ID { get; set; }
        public string UsuarioId { get; set; }

        public DateTime Fecha { get; set; }
        public Guid ClienteID { get; set; }
        public string Lugar { get; set; }
        public string PacienteID { get; set; }
        public string Telefono { get; set; }
        public Cliente Cliente { get; set; }
        public Paciente Paciente { get; set; }
    }
}
