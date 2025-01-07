using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using SistemaVentas.Web.MVC.Models;

namespace SistemaVentas.Web.MVC.Controllers
{
    [Route("categorias")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet()] ///http://<host>/categorias
        public async Task<IActionResult> Index()
        {
            ViewBag.CategoriaNueva = TempData["CategoriaNueva"];
            var modelo = await _categoriaRepository.Consultar();
            return View(modelo);
        }

        [HttpGet("{codigo}")] ///http://<host>/categorias/25
        public async Task<IActionResult> GetCategoriaById(int codigo)
        {
            return Ok();
        }


        [HttpGet("{nombre}/{codigo}")] ///http://<host>/categorias/computadoras/25/
        public async Task<IActionResult> GetCategoriaByIdNombre(int codigo, string nombre)
        {
            return Ok();
        }

        [HttpGet("query/{codigo}")] ///http://<host>/categorias/25?nombe=cpu
        public async Task<IActionResult> GetCategoriaByIdNombreQueryParam(int codigo, string nombre)
        {
            return Ok();
        }

        [HttpGet("registrar")]
        public async Task<IActionResult> Registrar()
        {
            return View();
        }

       
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(CategoriaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var dominio = new Categoria()
                {
                    Nombre = modelo.Nombre,
                    Activo =  true
                };
                _categoriaRepository.Registrar(dominio);
                TempData["CategoriaNueva"] = modelo.Nombre;
                //continua registro
                return RedirectToAction("Index");
            }
            else
            {
                    //mostrar mensaje de valicaión 
                    ViewBag.MensajeValidacion = "Error en la validación de datos";
                    return View();
            }
        }

        [HttpGet("modificar")]
        public async Task<IActionResult> Modificar(int codigo)
        {
            var modelo = await _categoriaRepository.ConsultarById(codigo);


            var viewModel = new CategoriaViewModel()
            {
                Id= modelo.IdCategoria,
                Nombre= modelo.Nombre               
            };

            return View(viewModel);
        }
        [HttpPost("modificar")]
        public async Task<IActionResult> Modificar(CategoriaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var dominio = new Categoria()
                {
                    IdCategoria = modelo.Id,
                    Nombre = modelo.Nombre,
                    Activo = true
                };
                _categoriaRepository.Modificar(dominio);
                
                //continua registro
                return RedirectToAction("Index");
            }
            else
            {
                //mostrar mensaje de valicaión 
                ViewBag.MensajeValidacion = "Error en la validación de datos";
                return View();
            }
        }


        [HttpPost("aprobar")]
        public async Task<IActionResult> Aprobar(CategoriaViewModel modelo)
        {
            return View();
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar(CategoriaViewModel modelo)
        {
            return View();
        }

    }
}
