using SistemaVentas.Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVentas.Dominio.Repositories
{
    public interface IClienteRepository
    {
        ValueTask<IEnumerable<Cliente>> Consultar(string nombre);
        Task<Cliente> ObtenerPorId(int id);
        Task Crear(Cliente cliente);
        Task Actualizar(Cliente cliente);
        Task Eliminar(int id);
    }
}
