using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;

namespace SistemaVentas.Web.RazorPages.Pages.Productos
{
    public class IndexModel : PageModel
    {

       // public IEnumerable<Producto> ListaProductos { get; set; }

        private readonly IProductoRepository _productoRepository;


        public IndexModel(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public void OnGet()
        {
           
        }
    }
}
