using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VetGest.Models
{
    public class Paciente
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ClienteID { get; set; } //id del paciente
        // datos del paciente---
        public string Nombre { get; set; }
        [Display(Name = "Fecha Nac.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Pelaje { get; set; }
        public string Sexo { get; set; }
        public string Chip { get; set; }


    }
}
