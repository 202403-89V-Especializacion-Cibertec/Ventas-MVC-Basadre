using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SistemaVentas.Web.MVC.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

       // public string? Accion { get; set; }
    }
}
