using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVentas.Servicios
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Consultar(string nombre)
        {
            return await _clienteRepository.Consultar(nombre);
        }

        public Task<Cliente> ObtenerPorId(int id)
        {
            return _clienteRepository.ObtenerPorId(id);
        }

        public Task Crear(Cliente cliente)
        {
            return _clienteRepository.Crear(cliente);
        }

        public Task Actualizar(Cliente cliente)
        {
            return _clienteRepository.Actualizar(cliente);
        }

        public Task Eliminar(int id)
        {
            return _clienteRepository.Eliminar(id);
        }
    }
}
