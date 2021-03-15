using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetGest.Models
{
    public class Cliente
    {
        [Key]
        public Guid ID { get; set; }
        //datos del propietario-----
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Nombre")]

        public string DueñoNombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Apellido")]

        public string DueñoApellido { get; set; }
        public string Domicilio { get; set; }
        public int? Telefono { get; set; }
    }
}
