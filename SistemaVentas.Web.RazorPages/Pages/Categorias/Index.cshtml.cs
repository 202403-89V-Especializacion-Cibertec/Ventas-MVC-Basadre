using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;

namespace SistemaVentas.Web.RazorPages.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Categoria> ListaCategorias { get;set; }
        private readonly ICategoriaRepository _categoriaRepository;
        public IndexModel(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task OnGet()
        {
            ListaCategorias = await _categoriaRepository.Consultar();
        }
    }
}
