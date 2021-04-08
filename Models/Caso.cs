using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace VetGest.Models
{
    public class Caso
    {
        [Key]
        public Guid ID { get; set; } // cambiar por un autogenerador incremental "CasoN°"
        [Display(Name = "Caso N°")]

        public int CasoN { get; set; }

        public Guid PacienteID { get; set; } //id del paciente
        public string UsuarioId { get; set; }
        public DateTime Fecha { get; set; } // fecha y hora de creacion

        public string MotivoConsulta { get; set; }
        public bool Activo { get; set; }
        public Usuario usuario { get; set; }
        public Paciente Paciente { get; set; }
        //public double? Peso { get; set; }
        //public double? Temperatura { get; set; }
        //public string EstadoCorporal { get; set; }
        //public string TiempoLlenadoCapilar { get; set; }
        //public string Hidratacion { get; set; }
        //public string FrecuenciaRespiratoria { get; set; }
        //public string FrecuenciaCardiaca { get; set; }
        //public string AllazgosClinicos { get; set; }
        //public string RecomendacionesMedicacion { get; set; }


    }
}
