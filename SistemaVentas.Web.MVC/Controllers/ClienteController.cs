using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using System.Threading.Tasks;

namespace SistemaVentas.Web.MVC.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Index()
        {
            var listado = await _clienteRepository.Consultar(null);
            return View(listado);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(new Cliente());
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteRepository.Crear(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _clienteRepository.ObtenerPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost("editar/{id}")]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _clienteRepository.Actualizar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var cliente = await _clienteRepository.ObtenerPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost("eliminar/{id}"), ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _clienteRepository.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

