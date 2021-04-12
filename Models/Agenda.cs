using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetGest.Models
{
    public class Agenda
    {
        public Guid AgendaID { get; set; }
        public Guid PacienteID { get; set; }
        public string UsuarioId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Evento { get; set; }
        public int TipoEvento { get; set; }

    }
}
