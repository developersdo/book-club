using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevDo.BookClub.Models
{
    public class Book
    {
        [Required(ErrorMessage = "El campo título es requerido.")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo autor es requerido.")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [StringLength(13)]
        [Required(ErrorMessage = "El campo ISBN es requerido.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "La imágen es requerida..")]
        [Display(Name = "Imágen")]
        public string CoverUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ISBN.Length > 13)
            {
                yield return new ValidationResult("El ISBN no puede contener mas de 13 digitos");
            }
        }
    }
}
