using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace VetGest.Models
{
    public class PlanSanitario
    {
        [Key]
        public Guid ID { get; set; }
        public string UsuarioId { get; set; }

        public Guid PacienteID { get; set; } //id del paciente
        public DateTime Fecha { get; set; } // fecha y hora de creacion
        public string VacunaAntiparasitario{ get; set; }
        public DateTime? FechaRefuerzo { get; set; } // fecha y hora de la siguente dosis (usar en una funcionde recordatorio)
        public Paciente Paciente { get; set; }


    }
}
