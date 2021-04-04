using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetGest.Models
{
    public class Cita
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime Fecha { get; set; } // fecha y hora de creacion
        public int? Peso { get; set; }
        public int? Temperatura { get; set; }
        public string EstadoCorporal { get; set; }
        public string TiempoLlenadoCapilar { get; set; }
        public string Hidratacion { get; set; }
        public string FrecuenciaRespiratoria { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public string AllazgosClinicos { get; set; }
        public string RecomendacionesMedicacion { get; set; }
        public DateTime FechaProximaCita { get; set; } // fecha y hora de la procima revision
    }
}
