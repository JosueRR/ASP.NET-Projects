using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class SchoolModel
    {
        // integer property representing the unique identifier of the school
        public int Id { get; set; }

        // string property representing the name of the school
        [Required(ErrorMessage = "Debe ingresar un nombre válido")]
        [DisplayName("Nombre de la escuela")]
        public string? Nombre { get; set; }

        // string property representing the province of the school
        [Required(ErrorMessage = "Debe ingresar una provincia válida")]
        [DisplayName("Provincia de la escuela")]
        public string? Provincia { get; set;}

        // string property representing the state or district of the school
        [Required(ErrorMessage = "Debe ingresar un estado válido")]
        [DisplayName("Estado o distrito de la escuela")]
        public string? Estado { get; set;}

        // integer property representing the number of classrooms in the school
        [Required(ErrorMessage = "Debe ingresar un número de aulas válido")]
        [DisplayName("Cantidad de Aulas de la escuela")]
        public int? NumeroAulas { get; set;}

        // boolean property indicating whether the school is public or not
        [Required(ErrorMessage = "Debe ingresar un si es verdadero que la escuela es pública o no. True or False")]
        [DisplayName("Es publica la escuela?")]
        public bool? EsPublica { get; set;}
    }
}
