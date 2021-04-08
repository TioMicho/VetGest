using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetGest.Models
{
    public class Revision
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CasoID { get; set; }
        public string UsuarioId { get; set; }
        public DateTime Fecha { get; set; } // fecha y hora de creacion
        public double? Peso { get; set; }
        public double? Temperatura { get; set; }
        public string EstadoCorporal { get; set; }
        public string TiempoLlenadoCapilar { get; set; }
        public string Hidratacion { get; set; }
        public string FrecuenciaRespiratoria { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public string AllazgosClinicos { get; set; }
        public string RecomendacionesMedicacion { get; set; }
        public DateTime? FechaProximaCita { get; set; } // fecha y hora de la procima revision
        public Caso Caso { get; set; }
    }
}
