using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [DisplayName("Nombre de la escuela")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Provincia")]
        [DisplayName("Provincia de la escuela")]
        public string? Provincia { get; set;}

        [Required(ErrorMessage = "Debe ingresar un Estado")]
        [DisplayName("Estado o distrito de la escuela")]
        public string? Estado { get; set;}

        [Required(ErrorMessage = "Debe ingresar un NumeroAulas")]
        [DisplayName("Cantidad de Aulas de la escuela")]
        public int? NumeroAulas { get; set;}

        [Required(ErrorMessage = "Debe ingresar un EsPublica")]
        [DisplayName("Es publica la escuela?")]
        public bool? EsPublica { get; set;}
    }
}
