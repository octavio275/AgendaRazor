using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de contacto es obligatorio")]
        [StringLength(15, ErrorMessage = "{0} El nombre debe tener entre {2} y {1}", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email de contacto es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono de contacto es obligatorio")]
        [StringLength(10, ErrorMessage = "{0} El nombre debe tener entre {2} y {1}", MinimumLength = 10)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime? FechaCreacion { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoría")]
        public Categoria Categoria { get; set; }

    }
}
